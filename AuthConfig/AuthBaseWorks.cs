
using EnhenceMultiAuth04v4.Configurations;
using EnhenceMultiAuth04V5.AuthConfig;
using Microsoft.Playwright;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhenceMultiAuth04V4.AuthConfig
{
    public enum AuthExecutionMode
    {
        Storage,   // reuse auth state
        Fresh,     // UI login every time
        Disabled   // no login
    }


    public class AuthSession
    {
        public IBrowserContext Context { get; }
        public IPage Page { get; }

        public AuthSession(IBrowserContext context, IPage page)
        {
            Context = context;
            Page = page;
        }
    }

    public static class AuthStateCleaner
    {
        public static void Remove(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }
    }




    public class AuthManager
    {
        private readonly IBrowser _browser;
        private readonly EnvironmentConfig _config;

        public AuthManager(IBrowser browser, EnvironmentConfig config)
        {
            _browser = browser;
            _config = config;
        }

        public async Task<AuthSession> CreateSessionAsync(
            string site,
            string role)
        {
            var siteCfg = _config.Sites[site];
            var storagePath = AuthStateService.GetPath(
                _config.Environment, site, role);

            IBrowserContext context;
            IPage page;

            // 1️⃣ Try using storage
            if (File.Exists(storagePath) ) //&& !TokenInspector.IsExpired(storagePath))
            {
                Log.Information("Using existing auth storage: {Path}", storagePath);

                context = await _browser.NewContextAsync(
                    new() { StorageStatePath = storagePath });

                page = await context.NewPageAsync();
                await page.GotoAsync(siteCfg.BaseUrl);

                // 2️⃣ VALIDATE SESSION
                if (await LoginPageDetector.IsLoginPageAsync(page, siteCfg))
                {
                    Log.Warning("Detected login page. Storage state invalid.");

                    await page.CloseAsync();
                    await context.CloseAsync();

                    // 3️⃣ Invalidate storage safely
                    await AuthFileLock.ExecuteAsync(storagePath, async () =>
                    {
                        AuthStateCleaner.Remove(storagePath);
                    });

                    // 4️⃣ Fresh login
                    return await CreateFreshSessionAsync(
                        site, role, siteCfg, storagePath);
                }

                Log.Information("Storage state valid. Continuing.");
                return new AuthSession(context, page);
            }

            // No storage / expired
            return await CreateFreshSessionAsync( site, role, siteCfg, storagePath);
        }

        private async Task<AuthSession> CreateFreshSessionAsync(string site,string role,SiteConfig siteCfg,string storagePath)
        {
            Log.Information("Performing fresh login for Site={Site}, Role={Role}", site, role);

            IBrowserContext context = null;
            IPage page = null;

            await AuthFileLock.ExecuteAsync(storagePath, async () =>
            {
                context = await _browser.NewContextAsync();
                page = await context.NewPageAsync();

                await page.GotoAsync(siteCfg.BaseUrl + siteCfg.LoginUrl);

                await SiteLoginRegistry.LoginAsync(site,page,siteCfg.Users[role]);

                await context.StorageStateAsync(new() { Path = storagePath });

                Log.Information("New auth storage created: {Path}", storagePath);
            });

            // Recreate clean context from new storage
            context = await _browser.NewContextAsync(new() { StorageStatePath = storagePath });

            page = await context.NewPageAsync();
            await page.GotoAsync(siteCfg.BaseUrl);

            return new AuthSession(context, page);
        }
    }


    public class AuthContextFactory
    {
        private readonly IBrowser _browser;
        private readonly EnvironmentConfig _config;

        public AuthContextFactory(IBrowser browser, EnvironmentConfig config)
        {
            _browser = browser;
            _config = config;
        }

        public async Task<AuthSession> CreateAsync(
            AuthExecutionMode mode,
            string site,
            string role)
        {
            return mode switch
            {
                AuthExecutionMode.Storage => await new AuthManager(_browser, _config).CreateSessionAsync(site, role),

                AuthExecutionMode.Fresh => await new UiLoginManager(_browser, _config).CreateSessionAsync(site, role),

                AuthExecutionMode.Disabled => await CreateAnonymousSessionAsync(),

                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private async Task<AuthSession> CreateAnonymousSessionAsync()
        {
            var context = await _browser.NewContextAsync();
            var page = await context.NewPageAsync();
            return new AuthSession(context, page);
        }
    }


    public static class AuthModeResolver
    {
        public static AuthExecutionMode Resolve(ScenarioContext ctx)
        {
            // 1️⃣ Scenario tag
            var tag = ctx.ScenarioInfo.Tags.FirstOrDefault(t => t.StartsWith("auth:"));

            if (tag != null && Enum.TryParse<AuthExecutionMode>(tag.Split(':')[1], true, out var mode))
            {
                return mode;
            }

            // 2️⃣ Environment variable
            var env = Environment.GetEnvironmentVariable("AUTH_MODE");
            if (!string.IsNullOrEmpty(env) && Enum.TryParse<AuthExecutionMode>(env, true, out mode))
            {
                return mode;
            }

            // 3️⃣ Default
            return AuthExecutionMode.Storage;
        }
    }


    public static class AuthStateService
    {
        static string projDirPath = Directory.GetCurrentDirectory().Split("bin")[0];
        static string auth1 = projDirPath + "/auth";
        public static string GetPath(string env, string site, string role)
        {

            var dir = Path.Combine(auth1, env);
            Directory.CreateDirectory(dir);
            return Path.Combine(dir, $"{site}_{role}.json");
        }
    }

    public static class AuthFileLock
    {
        private static readonly Dictionary<string, SemaphoreSlim> Locks = new();

        public static async Task ExecuteAsync(string key, Func<Task> action)
        {
            Locks.TryAdd(key, new SemaphoreSlim(1, 1));
            await Locks[key].WaitAsync();
            try { await action(); }
            finally { Locks[key].Release(); }
        }
    }







}//end-namespaces

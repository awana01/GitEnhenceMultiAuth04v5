using EnhenceMultiAuth04v4.Configurations;
using EnhenceMultiAuth04V4.AuthConfig;
using EnhenceMultiAuth04V5.AuthConfig;
using Microsoft.Playwright;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitEnhenceMultiAuth04V5.AuthWorkers
{
    public class AuthManager
    {
        private readonly IBrowser _browser;
        private readonly EnvironmentConfig _config;

        public AuthManager(IBrowser browser, EnvironmentConfig config)
        {
            _browser = browser;
            _config = config;
        }

        public async Task<AuthSession> CreateSessionAsync(string site, string role)
        {
            var siteCfg = _config.Sites[site];
            var storagePath = AuthStateService.GetPath(_config.Environment!, site, role);

            // ===============================
            // TRY EXISTING STORAGE
            // ===============================
            if (File.Exists(storagePath))
            {
                Log.Information("Using auth storage: {Path}", storagePath);

                var context = await _browser.NewContextAsync(
                    new() { StorageStatePath = storagePath });

                var page = await context.NewPageAsync();
                await page.GotoAsync(siteCfg.BaseUrl);

                // 🔐 Validate session
                if (!await LoginPageDetector.IsLoginPageAsync(page, siteCfg))
                {
                    Log.Information("Auth storage valid.");
                    EnsureSinglePage(context);
                    return new AuthSession(context, page);
                }

                // ❌ Invalid storage
                Log.Warning("Auth storage invalid. Re-login required.");

                await page.CloseAsync();
                await context.CloseAsync();

                await AuthFileLock.ExecuteAsync(storagePath, () =>
                {
                    AuthStateCleaner.Remove(storagePath);
                    return Task.CompletedTask;
                });
            }

            // ===============================
            // FRESH LOGIN FLOW
            // ===============================
            return await CreateFreshSessionAsync(site, role, siteCfg, storagePath);
        }

        private async Task<AuthSession> CreateFreshSessionAsync(
            string site,
            string role,
            SiteConfig siteCfg,
            string storagePath)
        {
            Log.Information("Fresh login: Site={Site}, Role={Role}", site, role);

            // 🔹 TEMP CONTEXT (login only)
            var tempContext = await _browser.NewContextAsync();
            var tempPage = await tempContext.NewPageAsync();

            await tempPage.GotoAsync(siteCfg.BaseUrl + siteCfg.LoginUrl);
            await SiteLoginRegistry.LoginAsync(
                site, tempPage, siteCfg.Users[role]);

            await tempContext.StorageStateAsync(
                new() { Path = storagePath });

            Log.Information("Auth storage created: {Path}", storagePath);

            // 🔥 MUST close temp login context
            await tempPage.CloseAsync();
            await tempContext.CloseAsync();

            // 🔹 FINAL CONTEXT (test usage)
            var context = await _browser.NewContextAsync(
                new() { StorageStatePath = storagePath });

            var page = await context.NewPageAsync();
            await page.GotoAsync(siteCfg.BaseUrl);

            EnsureSinglePage(context);
            return new AuthSession(context, page);
        }

        private static void EnsureSinglePage(IBrowserContext context)
        {
            if (context.Pages.Count > 1)
            {
                Log.Warning(
                    "Multiple pages detected in context. Count={Count}",
                    context.Pages.Count);
            }
        }
    }





    //public class AuthManager
    //{
    //    private readonly IBrowser _browser;
    //    private readonly EnvironmentConfig _config;

    //    public AuthManager(IBrowser browser, EnvironmentConfig config)
    //    {
    //        _browser = browser;
    //        _config = config;
    //    }

    //    public async Task<AuthSession> CreateSessionAsync(string site, string role)
    //    {
    //        var siteCfg = _config?.Sites?[site];
    //        var storagePath = AuthStateService.GetPath(_config!.Environment!, site, role);

    //        IBrowserContext context;
    //        IPage page;

    //        // 1️ Try using storage
    //        if (File.Exists(storagePath)) //&& !TokenInspector.IsExpired(storagePath))
    //        {
    //            Log.Information("Using existing auth storage: {Path}", storagePath);

    //            context = await _browser.NewContextAsync(
    //                new() { StorageStatePath = storagePath });

    //            page = await context.NewPageAsync();
    //            await page.GotoAsync(siteCfg!.BaseUrl!);

    //            // 2️ VALIDATE SESSION
    //            if (await LoginPageDetector.IsLoginPageAsync(page, siteCfg))
    //            {
    //                Log.Warning("Detected login page. Storage state invalid.");

    //                await page.CloseAsync();
    //                await context.CloseAsync();

    //                // 3️ Invalidate storage safely
    //                await AuthFileLock.ExecuteAsync(storagePath, async () =>
    //                {
    //                    AuthStateCleaner.Remove(storagePath);
    //                });

    //                // 4️ Fresh login
    //                return await CreateFreshSessionAsync(site, role, siteCfg, storagePath);
    //            }

    //            Log.Information("Storage state valid. Continuing.");
    //            return new AuthSession(context, page);
    //        }

    //        // No storage / expired
    //        return await CreateFreshSessionAsync(site, role, siteCfg, storagePath);
    //    }

    //    private async Task<AuthSession> CreateFreshSessionAsync(string site, string role, SiteConfig siteCfg, string storagePath)
    //    {
    //        Log.Information("Performing fresh login for Site={Site}, Role={Role}", site, role);

    //        IBrowserContext context = null;
    //        IPage page = null;

    //        await AuthFileLock.ExecuteAsync(storagePath, async () =>
    //        {
    //            context = await _browser.NewContextAsync();
    //            page = await context.NewPageAsync();

    //            await page.GotoAsync(siteCfg.BaseUrl + siteCfg.LoginUrl);

    //            await SiteLoginRegistry.LoginAsync(site, page, siteCfg.Users[role]);

    //            await context.StorageStateAsync(new() { Path = storagePath });

    //            Log.Information("New auth storage created: {Path}", storagePath);
    //        });

    //        // Recreate clean context from new storage
    //        context = await _browser.NewContextAsync(new() { StorageStatePath = storagePath });

    //        page = await context.NewPageAsync();
    //        await page.GotoAsync(siteCfg.BaseUrl!);

    //        return new AuthSession(context, page);
    //    }
    //}
}

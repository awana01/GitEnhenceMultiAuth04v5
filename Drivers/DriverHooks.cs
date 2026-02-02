using Allure.Net.Commons;
using EnhenceMultiAuth04v4.Configurations;
using EnhenceMultiAuth04v4.Core;
using EnhenceMultiAuth04V4.AuthConfig;
using Faker;
using Microsoft.Playwright;
using NUnit.Framework;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitEnhenceMultiAuth04V5.Drivers
{
    [Binding]
    public class DriverHooks
    {
        private IPlaywright _pw;
        private IBrowser _browser;
        private readonly ScenarioContext _ctx;

        public DriverHooks(ScenarioContext ctx) => _ctx = ctx;

        [OneTimeSetUp]
        public static void OneTimeSetup()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [BeforeScenario]
        public async Task Setup()
        {
            // -----------------------------
            // Resolve SpecFlow tags
            // -----------------------------
            var env = SpecFlowTagResolver.Resolve(_ctx, "env", "qa");
            var site = SpecFlowTagResolver.Resolve(_ctx, "site", "SiteA");
            var role = SpecFlowTagResolver.Resolve(_ctx, "role", "admin");

            Log.Information("=== Test Run Started | ENV={Env} ===", env);

            // -----------------------------
            // Load config
            // -----------------------------
            var config = ConfigLoader.Load();

            // -----------------------------
            // Headless resolution logic
            // -----------------------------
            bool headless = ResolveHeadlessMode(config);

            Log.Information(
                "Browser Launch Mode → Headless={Headless} | CI={CI} | HEADLESS={Override}",headless,
                Environment.GetEnvironmentVariable("CI"), Environment.GetEnvironmentVariable("HEADLESS")
            );

            // -----------------------------
            // Playwright bootstrap
            // -----------------------------
            _pw = await PlaywrightFactory.CreateAsync();
            _browser = await BrowserManager.LaunchAsync(_pw, headless);

            // -----------------------------
            // Auth context
            // -----------------------------
            var authMode = AuthModeResolver.Resolve(_ctx);
            var factory = new AuthContextFactory(_browser, config);
            var session = await factory.CreateAsync(authMode, site, role);

            _ctx.Set(session.Page);
            _ctx.Set(session.Context);
        }

        [AfterScenario]
        public async Task TearDown()
        {
            if (_browser != null)
                await _browser.CloseAsync();

            _pw?.Dispose();
        }

        // ======================================================
        // Headless decision logic
        // ======================================================
        private static bool ResolveHeadlessMode(EnvironmentConfig config)
        {
            // 1️ Explicit user override
            var headlessOverride = Environment.GetEnvironmentVariable("HEADLESS");
            if (bool.TryParse(headlessOverride, out bool forced))
                return forced;

            // 2️ CI auto-detection (GitHub, Azure DevOps, etc.)
            if (string.Equals(Environment.GetEnvironmentVariable("CI"),"true",StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            // 3️⃣ Local default (from config)
            return config.Headless;
        }
    }

}

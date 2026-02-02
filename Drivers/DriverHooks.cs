using EnhenceMultiAuth04v4.Core;
using EnhenceMultiAuth04V4.AuthConfig;
using Microsoft.Playwright;
using Reqnroll;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnhenceMultiAuth04v4.Drivers
{
    [Binding]
    public class DriverHooks
    {
        private IPlaywright _pw;
        private IBrowser _browser;
        private readonly ScenarioContext _ctx;

        public DriverHooks(ScenarioContext ctx) => _ctx = ctx;

        [BeforeScenario]
        public async Task Setup()
        {
            var env = SpecFlowTagResolver.Resolve(_ctx, "env", "qa");
            var site = SpecFlowTagResolver.Resolve(_ctx, "site", "SiteA");
            var role = SpecFlowTagResolver.Resolve(_ctx, "role", "admin");

            Environment.SetEnvironmentVariable("ENVIRONMENT", env);

            //LoggerBootstrap.Initialize(env);
            Log.Information("=== Test Run Started | ENV={Env} ===", env);

            var authMode = AuthModeResolver.Resolve(_ctx);

            var config = ConfigLoader.Load();

            _pw = await PlaywrightFactory.CreateAsync();
            _browser = await BrowserManager.LaunchAsync(_pw, config.Headless);

            var factory = new AuthContextFactory(_browser, config);
            var session = await factory.CreateAsync(authMode, site, role);

            // ✅ STORE PAGE ONLY
            _ctx.Set(session.Page);
            _ctx.Set(session.Context);

        }


        [AfterScenario]
        public async Task TearDown()
        {
            if (_browser != null)
                await _browser.CloseAsync();

            _pw?.Dispose();
            //Log.Information("=== Test Run Finished ===");
            //LoggerBootstrap.Shutdown();

        }
    }


}

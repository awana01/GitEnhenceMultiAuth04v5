using EnhenceMultiAuth04v4.Configurations;
using EnhenceMultiAuth04v4.Pages;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhenceMultiAuth04V4.AuthConfig
{
    public static class ConfigLoader
    {
        public static EnvironmentConfig Load()
        {
            var env = Environment.GetEnvironmentVariable("ENVIRONMENT") ?? "qa";
            
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("Config/appsettings.json", false)
                .AddJsonFile($"Config/appsettings.{env}.json", false)
                .Build();

            return config.Get<EnvironmentConfig>()!;
        }
    }


    public static class SiteLoginRegistry
    {
        public static Task LoginAsync(
            string site, IPage page, UserConfig user)
        {
            return site switch
            {
                "SiteA" => new SiteALoginPage(page).Login(user),
                "SocialNetwork" => new SiteBLoginPage(page).Login(user),
                _ => throw new NotSupportedException(site)
            };
        }
    }

    public static class SpecFlowTagResolver
    {
        public static string Resolve(ScenarioContext ctx, string key, string fallback)
        {
            return ctx.ScenarioInfo.Tags.FirstOrDefault(t => t.StartsWith($"{key}:"))?.Split(':')[1] ?? fallback;
        }
    }

    public class UiLoginManager
    {
        private readonly IBrowser _browser;
        private readonly EnvironmentConfig _config;

        public UiLoginManager(IBrowser browser, EnvironmentConfig config)
        {
            _browser = browser;
            _config = config;
        }

        public async Task<AuthSession> CreateSessionAsync(string site, string role)
        {
            var context = await _browser.NewContextAsync();
            var page = await context.NewPageAsync();

            var siteCfg = _config?.Sites?[site];
            await page.GotoAsync(siteCfg?.BaseUrl + siteCfg?.LoginUrl);

            await SiteLoginRegistry.LoginAsync(site, page, siteCfg!.Users![role]);

            // ✅ SAME PAGE USED FOR TEST
            return new AuthSession(context, page);
        }
    }


}

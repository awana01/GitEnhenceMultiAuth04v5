using EnhenceMultiAuth04v4.Configurations;
using EnhenceMultiAuth04V4.AuthConfig;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitEnhenceMultiAuth04V5.AuthWorkers
{
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
}

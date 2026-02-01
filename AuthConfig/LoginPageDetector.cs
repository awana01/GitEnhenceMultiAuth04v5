using EnhenceMultiAuth04v4.Configurations;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhenceMultiAuth04V5.AuthConfig
{
    public static class LoginPageDetector
    {
        public static async Task<bool> IsLoginPageAsync(IPage page, SiteConfig site)
        {
            // Strategy 1: URL-based (fast)
            if (page.Url.Contains(site.LoginUrl))
                return true;

            // Strategy 2: DOM-based (reliable)
            if (!string.IsNullOrEmpty(site.LoginIndicatorSelector))
            {
                return await page
                    .Locator(site.LoginIndicatorSelector)
                    .IsVisibleAsync();
            }

            return false;
        }
    }
}

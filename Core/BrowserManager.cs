using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnhenceMultiAuth04v4.Core
{


    public static class BrowserManager
    {
        public static Task<IBrowser> LaunchAsync(IPlaywright pw, bool headless)
        {
            return pw.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = headless });
        }
    }

}

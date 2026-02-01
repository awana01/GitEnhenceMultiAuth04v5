using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnhenceMultiAuth04v4.Core
{
    public static class PlaywrightFactory
    {
        public static Task<IPlaywright> CreateAsync()
            => Playwright.CreateAsync();
    }
}

using Microsoft.Playwright;
using NUnit.Framework;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnhenceMultiAuth04v4.Utils
{
    public class ProjUtil
    {
        public static async Task<byte[]> CaptureScreenshotBytes(IPage page, string screenshotName)
        {
            
            byte[] screenshotBytes = await page.ScreenshotAsync(new PageScreenshotOptions {FullPage = true });
            return screenshotBytes;
        }

        public static async Task<IReadOnlyList<IPage>> SwitchTab(IPage page,string title)
        {
            IReadOnlyList<IPage> Tabs = page.Context.Pages;
            return Tabs;
        }

        public static async Task<IPage> SwitchTab(IPage page, int tabIndex)
        {

            IReadOnlyList<IPage> Tabs = page.Context.Pages;
            return Tabs[tabIndex];
        }

        public static async Task<IPage> OpenNewTab(IPage page)
        {
            return await page.Context.NewPageAsync(); ;
        }

        public static string getBaseDirectory { get; } = Directory.GetCurrentDirectory().Split("bin")[0];

        public static string ProjectBaseDirectory
        {
            get { return AppContext.BaseDirectory; }
        }

        public static void RegisterLog(string logtext)
        {
            TestContext.Out.WriteLine(logtext);
            Log.Information(logtext);
        }



    }
}

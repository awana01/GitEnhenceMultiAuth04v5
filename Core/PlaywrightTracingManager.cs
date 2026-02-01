using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnhenceMultiAuth04v4.Core
{
    public static class PlaywrightTracingManager
    {
        public static async Task StartAsync(IBrowserContext context)
        {
            await context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });
        }

        public static async Task StopAsync(IBrowserContext context, string name)
        {
            await context.Tracing.StopAsync(new()
            {
                Path = $"traces/{name}.zip"
            });
        }
    }

}

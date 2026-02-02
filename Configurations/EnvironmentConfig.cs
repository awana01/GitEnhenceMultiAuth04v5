using System;
using System.Collections.Generic;
using System.Text;

namespace EnhenceMultiAuth04v4.Configurations
{
    public class EnvironmentConfig
    {
        public string? Environment { get; set; }
        public bool Headless { get; set; }

        public string? BrowserName { get; set; }
        public Dictionary<string, SiteConfig>? Sites { get; set; }
    }

}

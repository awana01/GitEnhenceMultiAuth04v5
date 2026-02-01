using System;
using System.Collections.Generic;
using System.Text;

namespace EnhenceMultiAuth04v4.Configurations
{
    public class SiteConfig
    {
        public string? BaseUrl { get; set; }
        public string? LoginUrl { get; set; }

        // NEW
        public string? LoginIndicatorSelector { get; set; }

        public Dictionary<string, UserConfig>? Users { get; set; }
    }


    public class UserConfig
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

}

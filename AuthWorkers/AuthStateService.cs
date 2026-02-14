using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitEnhenceMultiAuth04V5.AuthWorkers
{
    public static class AuthStateService
    {
        static string projDirPath = Directory.GetCurrentDirectory().Split("bin")[0];
        static string auth1 = projDirPath + "/auth";
        public static string GetPath(string env, string site, string role)
        {

            var dir = Path.Combine(auth1, env);
            Directory.CreateDirectory(dir);
            return Path.Combine(dir, $"{site}_{role}.json");
        }
    }
}

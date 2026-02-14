using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitEnhenceMultiAuth04V5.AuthWorkers
{
    public static class AuthStateCleaner
    {
        public static void Remove(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}

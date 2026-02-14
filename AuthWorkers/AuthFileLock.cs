using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitEnhenceMultiAuth04V5.AuthWorkers
{
    public static class AuthFileLock
    {
        private static readonly Dictionary<string, SemaphoreSlim> Locks = new();

        public static async Task ExecuteAsync(string key, Func<Task> action)
        {
            Locks.TryAdd(key, new SemaphoreSlim(1, 1));
            await Locks[key].WaitAsync();
            try { await action(); }
            finally { Locks[key].Release(); }
        }
    }
}

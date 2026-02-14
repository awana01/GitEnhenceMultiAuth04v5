using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitEnhenceMultiAuth04V5.AuthWorkers
{
    public class AuthSession
    {
        public IBrowserContext Context { get; }
        public IPage Page { get; }

        public AuthSession(IBrowserContext context, IPage page)
        {
            Context = context;
            Page = page;
        }
    }

    
}

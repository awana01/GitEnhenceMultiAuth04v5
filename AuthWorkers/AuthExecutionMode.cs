using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitEnhenceMultiAuth04V5.AuthWorkers
{
    public enum AuthExecutionMode
    {
        Storage,   // reuse auth state
        Fresh,     // UI login every time
        Disabled   // no login
    }
}

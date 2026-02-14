using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitEnhenceMultiAuth04V5.AuthWorkers
{
    public static class AuthModeResolver
    {
        public static AuthExecutionMode Resolve(ScenarioContext ctx)
        {
            // 1️⃣ Scenario tag
            var tag = ctx.ScenarioInfo.Tags.FirstOrDefault(t => t.StartsWith("auth:"));

            if (tag != null && Enum.TryParse<AuthExecutionMode>(tag.Split(':')[1], true, out var mode))
            {
                return mode;
            }

            // 2️⃣ Environment variable
            var env = Environment.GetEnvironmentVariable("AUTH_MODE");
            if (!string.IsNullOrEmpty(env) && Enum.TryParse<AuthExecutionMode>(env, true, out mode))
            {
                return mode;
            }

            // 3️⃣ Default
            return AuthExecutionMode.Storage;
        }
    }
}

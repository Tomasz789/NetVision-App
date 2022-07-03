using NetVision.Infrastructure.Services.ProcessService.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.Infrastructure.Services.ProcessService
{
    /// <summary>
    /// Class purposed for process launching.
    /// </summary>
    public sealed class ProcessLauncher
    {
        private readonly ProcessTypes type;
        private readonly string[] processList = new string[3] { "taskmgr", "cleanmgr", "control"};
        public ProcessLauncher(ProcessTypes processTypes)
        {
            type = processTypes;
        }

        /// <summary>
        /// Run a process by given type.
        /// </summary>
        /// <returns></returns>
        public int LaunchProcess()
        {
            string currentProcess = string.Empty;

            currentProcess = string.Concat(type.ToString().ToLowerInvariant(), ".exe");

            Process.Start(currentProcess);

           /* try
            {
                Process.Start(currentProcess);
            }
            catch
            {
                return -1;
            }*/

            currentProcess = string.Empty;

            return 0;
        }
    }
}

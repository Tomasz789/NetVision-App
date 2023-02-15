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

            if (type != ProcessTypes.DEVMGMT)
            {
                currentProcess = string.Concat(type.ToString().ToLowerInvariant(), ".exe");
            }
            else
            {
                currentProcess = type.ToString();
            }

            var info = new ProcessStartInfo(currentProcess)
            {
                Verb = "runAs",
                CreateNoWindow = true,
                UseShellExecute = true,
            };

            Process.Start(info);

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

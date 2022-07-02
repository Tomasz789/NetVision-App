using NetVision.DataCore.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NetVision.Infrastructure.Services
{
    public class ProcessInfoService : IProcessInfoService
    {
        /// <summary>
        /// Serach all processes and add to new list.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProcessModel> GetProcesses()
        {
            var proc_list = Process.GetProcesses();
            var values_to_return = new List<ProcessModel>();

            foreach (var proc in proc_list)
            {
                values_to_return.Add(new ProcessModel()
                {
                    Id = proc.Id,
                    Name = proc.ProcessName,
                    Status = proc.Responding.ToString(),
                    Memory = proc.PrivateMemorySize64,
                });
            }

            return values_to_return;
        }

        /// <summary>
        /// Get processes in pid range.
        /// </summary>
        /// <param name="minId">Minimum pid value.</param>
        /// <param name="maxId">Maximum pid value.</param>
        /// <returns></returns>
        public IEnumerable<ProcessModel> SearchInIdRange(long minId, long maxId, IEnumerable<ProcessModel> modelList)
        {
            var list_to_return = from p in modelList
                                 where p.Id >= minId && p.Id <= maxId
                                 select p;
            return list_to_return;
        }
    }
}

using NetVision.DataCore.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.Infrastructure.Services
{
    public interface IProcessInfoService
    {
        IEnumerable<ProcessModel> GetProcesses();
        IEnumerable<ProcessModel> SearchInIdRange(long minId, long maxId, IEnumerable<ProcessModel> modelList);
    }
}

using NetVision.DataCore.Model;
using NetVision.DataCore.PerformanceValueTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.Infrastructure.Services
{
    public interface IPerformanceService
    {
       // IEnumerable<PerformanceModel> GetPerformanceValues();
        public Task<float> CPU_MeasureUsage();
        public Task<float> RAM_Total_Usage();
        public Task<float> RAM_Current_Usage();
        public Task<float> RAM_Available();
        //Task<float> GetPerformanceValuesAsync(PerformanceValueType type);
    }
}

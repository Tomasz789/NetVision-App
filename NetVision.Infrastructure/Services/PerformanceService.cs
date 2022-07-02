using NetVision.DataCore.Model;
using NetVision.DataCore.PerformanceValueTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NetVision.Infrastructure.Services
{
    public class PerformanceService : IPerformanceService
    {
        private readonly PerformanceCounter cpuUsage = new PerformanceCounter("Processor", "% Processor Time", "_Total");    //licznik zużycia CPU
       /* private readonly PerformanceCounter ramUsage = new PerformanceCounter("Memory", "% Committed Bytes In Use");         //licznik zużycia Ram
        private readonly PerformanceCounter availableRam = new PerformanceCounter("Memory", "Available MBytes");               //dostępna pamięć RAM
        private readonly PerformanceCounter totalRam = new PerformanceCounter("Process", "Working Set", "_Total");           //całkowita pamięc RAM
        private readonly PerformanceCounter temp = new PerformanceCounter("Thermal Zone Information", "Temperature", @"\_TZ.THRM");
        */
        public async Task<float> CPU_MeasureUsage()
        {
            float value_to_return = 0f;
            //using (var cpuUsage = new PerformanceCounter("Processor", "% Processor Time", "_Total"))
            //{
                value_to_return = cpuUsage.NextValue();
            //}
            await Task.CompletedTask;
            return value_to_return;
        }

        public async Task<float> RAM_Total_Usage()
        {
            float value_to_return = 0f;
            using (var ramTotalUsage = new PerformanceCounter("Process", "Working Set", "_Total"))
            {
                value_to_return = ramTotalUsage.NextValue();
            }
            await Task.CompletedTask;
            return value_to_return;
        }

        public async Task<float> RAM_Current_Usage()
        {
            float value_to_return = 0f;
            using (var ramCurrentUsage = new PerformanceCounter("Memory", "Available MBytes"))
            {
                value_to_return = ramCurrentUsage.NextValue();
            }
            await Task.CompletedTask;
            return value_to_return;
        }

        public async Task<float> RAM_Available()
        {
            float value_to_return = 0f;
            using (var ram= new PerformanceCounter("Memory", "% Committed Bytes In Use"))
            {
                value_to_return = ram.NextValue();
            }
            await Task.CompletedTask;
            return value_to_return;
        }


      /*  public Task<float> GetPerformanceValuesAsync(PerformanceValueType type)
        {
            float valueToReturn = 0f;
            switch (type)
            {
                case PerformanceValueType.CPU:
                    valueToReturn = cpuUsage.NextValue();
                    break;
                case PerformanceValueType.RAM_TOTAL:
                    valueToReturn = totalRam.NextValue();
                    break;
                case PerformanceValueType.RAM_CURRENT:
                    valueToReturn = ((float)(ramUsage.NextValue() / 1.204E+06));
                    break;
                case PerformanceValueType.RAM_AVAILABLE:
                    valueToReturn = availableRam.NextValue();
                    break;
            }
            return Task.FromResult(valueToReturn);
        }

        public IEnumerable<PerformanceModel> GetPerformanceValues()
        {

            yield return new PerformanceModel()
            {
                CPU_Usage = cpuUsage.NextValue(),
                RAM_Current = (float)(ramUsage.NextValue() / 1.024E+06),
                RAM_Available = availableRam.NextValue(),
                RAM_Total_Usage = totalRam.NextValue()
                
            };
         }*/
    }
}

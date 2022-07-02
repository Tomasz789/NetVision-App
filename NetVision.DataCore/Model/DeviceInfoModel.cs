using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.DataCore.Model
{
    public class DeviceInfoModel
    {
        public string CPU_Name { get; set; }
        public string User_Dev_Name { get; set; }
        public string PhisycalProcessorsNumber { get; set; }
        public string LogicalProcessorNumber { get; set; }
        public string NumberOfBits { get; set; }
        public string NumberOfCores { get; set; }
        public string GraphicalDevName { get; set; }
    }
}

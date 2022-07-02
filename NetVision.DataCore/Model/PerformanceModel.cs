using NetVision.DataCore.PropertyUpdater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.DataCore.Model
{
    public class PerformanceModel
    {

        public float CPU_Usage { get; set; }
        public float RAM_Total_Usage { get; set; }

        public float RAM_Current { get; set; }

        public float RAM_Available { get; set; }
    }
}

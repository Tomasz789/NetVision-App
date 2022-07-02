using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.DataCore.Model
{
    public class DriveModel
    {
        public string Name { get; set; }
        public string Format { get; set; }
        public long TotalSpace { get; set; }
        public long AvailableSpace { get; set; }
        public string Directory { get; set; }

        public DriveModel()
        {

        }
    }
}

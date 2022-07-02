using NetVision.DataCore.PropertyUpdater;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.DataCore.Model
{
    public class PingModel
    {
        
        public int Counts { get; set; }
       
        public string Address { get; set; }
        public string Data { get; set; }

        public long Timeout { get; set; }
        
        public int TTL { get; set; }

        public int BufferLength { get; set; }
      

        public string State { get; set; }
       

        public string Host { get; set; }
       
    }
}


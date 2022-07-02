using NetVision.DataCore.PropertyUpdater;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.DataCore.Model
{
    public class TraceEntryModel : IDataErrorInfo
    {
        private int hopcounter;
        private string address, hostname, status;
        private long timeout;

        public string this[string columnName]
        {
            get
            {
                string msg = string.Empty;

                switch (columnName)
                {
                    case "Address":
                        {
                            if (string.IsNullOrWhiteSpace(Address))
                                msg = "Invalid address format";
                        }
                        break;
                    case "HopCounter":
                        {
                            if (HopCounter < 0)
                                msg = "Invalid hop numbers";
                        }
                        break;
                    case "Timeout":
                        {
                            if (Timeout < 0)
                                msg = "Ivalid timeout - must be bigger than 0";
                            
                        }
                        break;
                }
                return msg;
            }
        }

        public int HopCounter { get; set; }
        public string Address { get; set; }
        public string HostName { get; set; }
        public long Timeout { get; set; }
        public string Status { get; set; }
        public float AvgTimeout { get; set; }
        public long MinTimeout { get; set; }
        public long MaxTimeout { get; set; }

        public string Error => throw new NotImplementedException();
    }
}

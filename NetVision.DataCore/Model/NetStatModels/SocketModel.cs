using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.DataCore.Model.NetStatModels
{
    public class SocketModel
    {
        public string LocalEndpoint { get; set; }
        public string RemoteEndpoint { get; set; }
        public string Status { get; set; }
        public string SocketType { get; set; }
    }
}

using NetVision.DataCore.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.DataCore.Model
{
    public static class SocketModel
    {
        public static long ResponseTimeout { get; set; }
        public static long ReceiveTimeout { get; set; }
        public static long TotalTimeout { get; set; }
        public static string Status { get; set; }
        public static int Port { get; set; }
        public static string Address { get; set; }
        public static string InfoMsg { get; set; }
        public static SocketType Type { get; set; }
        public static bool IsConnected { get; set; }
        public static int DataLength { get; set; }

        public static string ReceivedData { get; set; }
    }
}

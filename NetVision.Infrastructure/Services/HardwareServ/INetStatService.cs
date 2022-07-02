using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.Infrastructure.Services.HardwareServ
{
    public interface INetStatService
    {
        IEnumerable<TcpConnectionInformation> GetTcpConnectionList();
        IEnumerable<IPEndPoint> GetUdpStatistics();
        IEnumerable<TcpStatistics> GetTcpStatisticsForIPv4();
        IEnumerable<TcpStatistics> GetTcpStatisticsForIPv6();
        IEnumerable<Process> GetProcessList();
    }
    public class NetStatService : INetStatService
    {
        private readonly IPGlobalProperties iPGlobalProperties;

        public NetStatService()
        {
            iPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
        }

        //----------------process properties-----------------
        public IEnumerable<Process> GetProcessList()
        {
            throw new NotImplementedException();
        }

        //---------------get tcp active connections----------------------
        public IEnumerable<TcpConnectionInformation> GetTcpConnectionList()
        {
            var tcp_list = iPGlobalProperties.GetActiveTcpConnections();
            return tcp_list.AsEnumerable();
        }

        public IEnumerable<TcpStatistics> GetTcpStatisticsForIPv4()
        {
            var tcp_stats = iPGlobalProperties.GetTcpIPv4Statistics();
            ISet<TcpStatistics> tcpStatistics = new HashSet<TcpStatistics>();
            tcpStatistics.Add(tcp_stats);
            return tcpStatistics;
        }

        public IEnumerable<TcpStatistics> GetTcpStatisticsForIPv6()
        {
            throw new NotImplementedException();
        }

        //--------------get udp connections stats--------------------------
        public IEnumerable<IPEndPoint> GetUdpStatistics()
        {
            var udp_stats = iPGlobalProperties.GetActiveUdpListeners();
            return udp_stats.AsEnumerable();
        }
    }
}

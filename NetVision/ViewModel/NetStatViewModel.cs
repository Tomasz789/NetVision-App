using NetVision.Infrastructure.Services.HardwareServ;
using NetVision.ViewModel.PropertyUpdater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.ViewModel
{
    public class NetStatViewModel : ViewModelPropertyUpdater
    {
        private INetStatService _netService;
        public NetStatViewModel()
        {
            _netService = new NetStatService();
        }
        public IEnumerable<TcpConnectionInformation> TcpInfoList => _netService.GetTcpConnectionList();
        public IEnumerable<IPEndPoint> UdpInfoList => _netService.GetUdpStatistics();
        public IEnumerable<TcpStatistics> TcpIPv4List => _netService.GetTcpStatisticsForIPv4();
    }
}

using NetVision.DataCore.Model;
using NetVision.Infrastructure.Services;
using NetVision.MVRelayCmds;
using NetVision.Updater;
using NetVision.ViewModel.PropertyUpdater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NetVision.ViewModel
{
    public class NetInfoViewModel : ViewModelPropertyUpdater
    {
        private IList<NetworkInfoModel> _netStats;
        private NetworkInfoModel _netInfo;
        private IPGlobalProperties _properties;
        private INetworkingInfoService _service;
        private ICommand cmd;

        public NetInfoViewModel()
        {
            InitializeViewModel();
        }

        private void InitializeViewModel()
        {
            _netStats = new List<NetworkInfoModel>();
            _service = new NetworkingInfoService();
           
            GetNetworkInformation();
        }
        public IList<NetworkInfoModel> NetworkInfos
        {
            get
            {
                return _netStats;
            }
            set
            {
                _netStats = value;
                OnPropertyChanged("NetList");
            }
        }
        public NetworkInfoModel CardInfo
        {
            get
            {
                return _netInfo;
            }
            set
            {
                _netInfo = value;
            }
        }

        private void GetNetworkInformation()
        {
            foreach (var item in _service.GetAllInterfaces())
                _netStats.Add(new NetworkInfoModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Speed = item.Speed,
                    Status = item.Status,
                    PhysicalAddress = item.PhysicalAddress,
                    DhcpAddresses = item.DhcpAddresses,
                    DnsAddresses = item.DnsAddresses,
                    GatewayAddresses = item.GatewayAddresses
                });

        }
    }

}

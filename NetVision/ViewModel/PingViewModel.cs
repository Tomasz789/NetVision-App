using NetVision.DataCore.Model;
using NetVision.Infrastructure.Services;
using NetVision.MVRelayCmds;
using NetVision.Updater;
using NetVision.ViewModel.PropertyUpdater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NetVision.ViewModel
{
    public class PingViewModel : ViewModelPropertyUpdater
    {
        private readonly IPingInfoService _pingInfoService;
        private IList<PingModel> _pingInfoList;
        private PingModel _pingModel = new PingModel();
      
        public PingViewModel(IPingInfoService pingInfoService)
        {
            _pingInfoService = pingInfoService;
            GetPingCommand = new RelayCommand(GetPing, CanExecute);
            _pingModel = new PingModel()
            {
                Address = "www.google.com",
                BufferLength = 4,
                Timeout = 1000,
                Data = "aaaa",
                TTL = 4
            };
        }

        public IList<PingModel> PingInfoList
        {
            get
            {
                return _pingInfoList;
            }
            set
            {
                _pingInfoList = value;
            }
        }

        public int Counts
        {
            get
            {
                return _pingModel.Counts;
            }
            set
            {
                _pingModel.Counts = value;
                OnPropertyChanged("Counts");
            }
        }
        public string Address
        {
            get
            {
                return _pingModel.Address;
            }
            set
            {
                _pingModel.Address = value;
                OnPropertyChanged("Address");

            }
        }

        public string Host
        {
            get
            {
                return _pingModel.Host;
            }
            set
            {
                _pingModel.Host = value;
                OnPropertyChanged("Host");
            }
        }
        public long Timeout
        {
            get
            {
                return _pingModel.Timeout;
            }
            set
            {
                _pingModel.Timeout = value;
                OnPropertyChanged("Timeout");
            }
        }
        public int TTL
        {
            get
            {
                return _pingModel.TTL;
            }
            set
            {
                _pingModel.TTL = value;
                OnPropertyChanged("TTL");
            }
        }
        public int BufferLength
        {
            get
            {
                return _pingModel.BufferLength;
            }
            set
            {
                _pingModel.BufferLength = value;
                OnPropertyChanged("BufferLength");
            }
        }
      
        public ICommand GetPingCommand { get; set; }
        public string Data { get;  set; }

        private bool CanExecute(object param)
        {
            return true;
        }

        private async Task SendPingAsyncThread()
        {
            _pingInfoList = new List<PingModel>();
            var options = new PingOptions();
            var _pingInfo = new PingModel();

         //   Host = Address;
          
            var reply = await _pingInfoService.SendPing(Address, Encoding.ASCII.GetBytes(Data), Convert.ToInt32(Timeout), options);

            for (int i = 0; i < Counts; ++i)
            {

                _pingInfoList.Add(new PingModel()
                {
                    Address = reply.Address.ToString(),
                    Data = Encoding.ASCII.GetString(reply.Buffer),
                    BufferLength = reply.Buffer.Length,
                    Timeout = reply.RoundtripTime,
                    TTL = reply.Options.Ttl,
                    State = reply.Status.ToString(),
                    Host = Address,
                });
            }
            await Task.Delay((int)Timeout);
        }
        private void GetPing(object param)
        {
            var _pingInfo = new PingModel();
            _pingInfoList = new List<PingModel>();
            var options = new PingOptions();

             SendPingAsyncThread();
                
           
           
           /* for (int i = 0; i < Counts; ++i)
            {
                Host = Address;
                _pingInfoService.SendPing(Address, Encoding.ASCII.GetBytes("aaaa"), Convert.ToInt32(Timeout), options);

                _pingInfo.Address = _pingInfoService.GetAddress();
                _pingInfo.BufferLength = _pingInfoService.GetBufferLength();
                _pingInfo.Timeout = _pingInfoService.GetTimeout();
                _pingInfo.TTL = _pingInfoService.GetTTL();

                _pingInfoList.Add(_pingInfo);
            }*/
            
        }
    }
}

using NetVision.DataCore.Messages;
using NetVision.ViewModel.PropertyUpdater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.ViewModel
{
    public class SocketViewModel : ViewModelPropertyUpdater
    {
        private InfoMessage _infoMsg;
        public SocketViewModel()
        {
            _infoMsg = new InfoMessage("Socket Analyzer opened.");
        }

        public int Timeout { get; set; }
        public string Message { get; set; }
        public int Port { get; set; }
        public string Address { get; set; }
        public InfoMessage InfoMsg { get; set; }
        public SocketType Type { get; set; }
        public bool IsConnected { get; set; }
    }
}

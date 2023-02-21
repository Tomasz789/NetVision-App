using NetVision.DataCore.Model;
using NetVision.Infrastructure.Services.States;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.Infrastructure.Services
{
    public interface IPingInfoService
    {
        Task<PingReply> SendPing(string addr, byte[] data, int timeout, PingOptions opts);
        IPAddress GetAddressFromHostName(string hostName);
        string GetNameFromAddress(IPAddress address);

        public PingState PingState { get; }
    }

   
}


using NetVision.DataCore.Model;
using NetVision.Infrastructure.Services.States;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.Infrastructure.Services
{
    public class PingInfoService : IPingInfoService
    {
        public PingState pingState;
        
        public async Task<PingReply> SendPing(string addr, byte[] data, int counts, PingOptions opts)
        {
            var ping = new Ping();  //new ping
            var reply = await ping.SendPingAsync(GetAddressFromHostName(addr), 1000, data, opts);   //send ping
           

            return reply;
        }

        public PingState GetPingState()
        {
            return pingState;
        }

        public bool CancelPingAsync()
        {
            return true;
        }

        public IPAddress GetAddressFromHostName(string hostName)
        {
            IPAddress address_to_return = null;
            if (hostName == null || string.IsNullOrEmpty(hostName))
                throw new Exception("Bad hostname format!");

            IPAddress[] addresses = Dns.GetHostAddresses(hostName);
            foreach (IPAddress iPAddress in addresses)
                address_to_return = iPAddress;
            return address_to_return;
        }
    }
}


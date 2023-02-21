using NetVision.DataCore.Model;
using NetVision.DataException;
using NetVision.DataException.Exceptions;
using NetVision.Infrastructure.Services.States;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetVision.Infrastructure.Services
{
    public class PingInfoService : IPingInfoService, IDisposable
    {
        private PingState pingState;
        private readonly Ping ping;

        public PingInfoService()
        {
            ping = new Ping();
        }

        public PingState PingState => pingState;


        /// <summary>
        /// Asynchronous task purposed to send a ping.
        /// </summary>
        /// <param name="addr">String representation of IP address or hostname.</param>
        /// <param name="data">Array of bytes representing data to send.</param>
        /// <param name="timeout">Timeout between request send.</param>
        /// <param name="opts">Additional ping options.</param>
        /// <returns>Reply from ping method.</returns>
        /// <exception cref="IPAddressException">If cannot get ip address from hostname.</exception>
        public async Task<PingReply> SendPing(string addr, byte[] data, int timeout, PingOptions opts)
        {
            var ipAddr = GetAddressFromHostName(addr);

            if (ipAddr == null)
            {
                throw new IPAddressException("Cannot obtain any IP address");
            }

            ping.PingCompleted += new PingCompletedEventHandler(PingCompletedCallback);

            var reply = await ping.SendPingAsync(ipAddr, timeout, data, opts);   // send ping

            return reply;
        }


        public void PingCompletedCallback(object sender, PingCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                pingState = PingState.Error;
                ((AutoResetEvent)e.UserState).Set();
                Dispose();
            }

            if (e.Cancelled)
            {
                pingState = PingState.Completed;
                ((AutoResetEvent)e.UserState).Set();
                Dispose();
            }

            pingState = PingState.Running;

        }
        public PingState GetPingState()
        {
            return pingState;
        }

        /// <summary>
        /// Method allows to get ip from hostname.
        /// </summary>
        /// <param name="hostName">String representation of hostname.</param>
        /// <returns>IP address.</returns>
        /// <exception cref="InvalidHostException"></exception>
        public IPAddress GetAddressFromHostName(string hostName)
        {
            IPAddress address_to_return = null;
            if (hostName == null || string.IsNullOrEmpty(hostName))
            {
                throw new InvalidHostException(hostName);
            }

            IPAddress[] addresses = Dns.GetHostAddresses(hostName);

            foreach (IPAddress iPAddress in addresses)
            {
                address_to_return = iPAddress;
            }

            return address_to_return;
        }

        /// <summary>
        /// Get host name based on IP address.
        /// </summary>
        /// <param name="address">IP address as an IPAddress object.</param>
        /// <returns></returns>
        public string GetNameFromAddress(IPAddress address)
        {
            try
            {
                var hostname = Dns.GetHostEntry(address).HostName;
                return hostname;
            }
            catch (SocketException)
            {
                return address.ToString();
            }
        }

        public void Dispose()
        {
            ping.Dispose();
        }
    }
}


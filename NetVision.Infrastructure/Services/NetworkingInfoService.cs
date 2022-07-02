using NetVision.DataCore.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace NetVision.Infrastructure.Services
{
    public class NetworkingInfoService : INetworkingInfoService
    {
        private IPGlobalProperties _properties;


        IList<NetworkInfoModel> _interfaces;

        public NetworkingInfoService()
        {
            _properties = IPGlobalProperties.GetIPGlobalProperties();
            _interfaces = new List<NetworkInfoModel>();
        }

        
        public IEnumerable<NetworkInfoModel> GetAllInterfaces()
        {
            var dns = new List<string>();
            var dhcp = new List<string>();
            var gateways = new List<string>();

            foreach (NetworkInterface inter in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (var gatewayAddr in inter.GetIPProperties().GatewayAddresses)   //looking for gateway addresses
                    gateways.Add(gatewayAddr.ToString());
                foreach (var dnsAddr in inter.GetIPProperties().DnsAddresses)           //dns addr
                    dns.Add(dnsAddr.ToString());
                foreach (var dhcpAddr in inter.GetIPProperties().DhcpServerAddresses)       //dhcp
                    dhcp.Add(dhcpAddr.ToString());

                yield return new NetworkInfoModel()
                {
                    Id = inter.Id,
                    Name = inter.Name,
                    Description = inter.Description,
                    Status = inter.OperationalStatus.ToString(),
                    Speed = (inter.Speed / (double)1000000).ToString(),
                    PhysicalAddress = inter.GetPhysicalAddress().ToString(),
                    DnsAddresses = dns,
                    DhcpAddresses = dhcp,
                    GatewayAddresses = gateways,
                };
            }
        }


        public string GetDomainName()
        {
            return _properties.DomainName;
        }


        public string GetHostName()
        {
            return _properties.HostName;
        }

        public NetworkInfoModel GetInterfaceByName(string name)
        {
            return GetAllInterfaces().FirstOrDefault(r => r.Name == name);
        }


        [DllImport("wininet.dll")]
        private static extern bool InternetGetConnectedState(out int conn, int val);
        public bool GetInternetState()
        {
            int state;

            if (InternetGetConnectedState(out state, 0))
                return true;
            else return false;
        }
    }
}


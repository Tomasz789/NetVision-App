using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

namespace NetVision.Infrastructure.Services
{
    public class ProtocolsStats : IProtocolsStats
    {
        private TcpConnectionInformation[] _tcpInfo;
        private IPEndPoint[] _tcpListeners;
        private IPEndPoint[] _udpListeners;
        private IPGlobalProperties _properties;
        public ProtocolsStats()
        {
            _properties = IPGlobalProperties.GetIPGlobalProperties();
        }
        public IList<TcpConnectionInformation> GetActiveConnections()
        {
            IList<TcpConnectionInformation> tcpList = new List<TcpConnectionInformation>();
            if (_properties is null) throw new Exception("Null list");

            _tcpInfo = _properties.GetActiveTcpConnections();
            foreach (var tcp in _tcpInfo)
            {
                tcpList.Add(tcp);
            }

            return tcpList;
        }

        public IList<IPEndPoint> GetTcpServers()
        {
            IList<IPEndPoint> tcpList = new List<IPEndPoint>();
            if (_properties is null) throw new Exception("Null list");

            _tcpListeners = _properties.GetActiveTcpListeners();

            foreach (var tcp in _tcpListeners)
                tcpList.Add(tcp);

            return tcpList;
        }

        public IList<IPEndPoint> GetUdpServers()
        {
            IList<IPEndPoint> udpList = new List<IPEndPoint>();
            if (_properties is null) throw new Exception("Null list");

            _udpListeners = _properties.GetActiveTcpListeners();

            foreach(var udp in _udpListeners)
            {
                udpList.Add(udp);
            }
            return udpList;
        }
    }
}

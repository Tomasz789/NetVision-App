using NetVision.Infrastructure.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.TestLib.NetworkingTests
{
    [TestFixture]
    public class HostAddressTests
    {
        private IPingInfoService _service;
        private readonly string hostname = "www.google.com";
        private readonly string hostaddress = "216.58.215.100";

        [SetUp]
        public void Init()
        {
            _service = new PingInfoService();
        }

        [Test]

        public void GetHostNameForAddress_Test()
        {
            var ip = IPAddress.Parse(hostaddress);
            var addr = _service.GetNameFromAddress(ip);

            Assert.IsNotNull(addr);
            Assert.AreEqual(addr, hostname);
        }

        [Test]

        public void GetAddressFromHostName_Test()
        {
            var hostIp = _service.GetAddressFromHostName(hostname).ToString();

            Assert.IsNotNull(hostIp);
            Assert.AreEqual(hostIp, hostaddress);
        }
    }
}

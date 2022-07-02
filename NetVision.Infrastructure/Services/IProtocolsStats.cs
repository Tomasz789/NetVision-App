using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.Infrastructure.Services
{
    public interface IProtocolsStats
    {
        IList<IPEndPoint> GetTcpServers();
        IList<IPEndPoint> GetUdpServers();
        IList<TcpConnectionInformation> GetActiveConnections();
    }
}
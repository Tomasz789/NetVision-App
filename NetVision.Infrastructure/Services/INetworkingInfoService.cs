using NetVision.DataCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.Infrastructure.Services
{
    public interface INetworkingInfoService
    {
        string GetHostName();
        string GetDomainName();
        bool GetInternetState();
        IEnumerable<NetworkInfoModel> GetAllInterfaces();
        NetworkInfoModel GetInterfaceByName(string name);
    }
}


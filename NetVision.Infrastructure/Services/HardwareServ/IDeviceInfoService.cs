using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.Infrastructure.Services.HardwareServ
{
    public interface IDeviceInfoService
    {
        Task<IList<string>> GetDeviceProperty(string category, string prop);
    }

    public class DeviceInfoService : IDeviceInfoService
    {
        public Task<IList<string>> GetDeviceProperty(string category, string prop)
        {
            ManagementObjectSearcher objectSearcher;
            IList<string> _objList = new List<string>();
            string result = "";

            if (category != null || string.IsNullOrEmpty(prop) == false)
                objectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + category);
            else throw new ArgumentException("Category is empty");

            foreach (var item in objectSearcher.Get())
            {
                _objList.Add(item.ToString());
            }

            return Task.FromResult(_objList);
        }
    }
}

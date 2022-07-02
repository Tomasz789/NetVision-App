using NetVision.DataCore.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.Infrastructure.Services.HardwareServ
{
    public interface IDriveService
    {
        Task<IList<DriveInfo>> GetDrivers();
        Task<DriveInfo> GetCurrentDrive(string driveName);
    }
}

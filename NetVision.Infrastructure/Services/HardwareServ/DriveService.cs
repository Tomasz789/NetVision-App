using NetVision.DataCore.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NetVision.Infrastructure.Services.HardwareServ
{
    public class DriveService : IDriveService
    {
        IList<DriveInfo> _drivers;
        private DriveInfo [] _driversList;

        public DriveService()
        {
            _drivers = new List<DriveInfo>();
        }
        
        private string error_msg = "";

        public async Task<DriveInfo> GetCurrentDrive(string driveName)
        {
            if (_drivers is null)
                throw new Exception("Empty list!");
            var drive = _drivers.FirstOrDefault(r => r.Name == driveName);
            return await Task.FromResult(drive);
        }

        public async Task<IList<DriveInfo>> GetDrivers()
        {
            _drivers = new List<DriveInfo>();
           

            try
            {
                _driversList = DriveInfo.GetDrives();
            }
            catch(Exception ex)
            {
                error_msg = "Cannot obtain drive information!" + ex.Message;
            }

            foreach(var drive in _driversList)
            {
                _drivers.Add(drive);
            }

            var all_drivers = (from item in _drivers
                                     select item).ToList();

            return await Task.FromResult(all_drivers);
        }
    }
}

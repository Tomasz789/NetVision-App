using System;
using System.Collections.Generic;
using System.Management;

namespace NetVision.Infrastructure.Services
{
    public class BiosInformationService : IBiosInformationService
    {
        private IList<string> _informationList;
        public IEnumerable<string> GetBiosInformation()
        {
            SelectQuery sq = new SelectQuery("Win32_BIOS"); //new query form Bios info table
            ManagementObjectSearcher objectSearcher = new ManagementObjectSearcher(sq); //searcher of os details with sq arg
            ManagementObjectCollection objectsCollection = objectSearcher.Get();    //get all elements collection
            _informationList = new List<string>();  //create a new obj list
            
            //get the BIOS version
            foreach(ManagementObject obj in objectsCollection)
            {
                string[] version = (string[])obj["BIOSVersion"];
                string tmp = null;
                foreach(string current_version in version)
                {
                    tmp = tmp + current_version;
                }

                _informationList.Add(tmp);
                _informationList.Add(obj["Caption"].ToString());
                _informationList.Add(obj["Description"].ToString());
               // _informationList.Add(obj["InstallDate"].ToString());
                _informationList.Add(obj["Manufacturer"].ToString());
                _informationList.Add(obj["PrimaryBIOS"].ToString());
                _informationList.Add(obj["ReleaseDate"].ToString());
                _informationList.Add(obj["SerialNumber"].ToString());
                _informationList.Add(obj["SoftwareElementID"].ToString());
                _informationList.Add(obj["SoftwareElementState"].ToString());
                _informationList.Add(obj["Status"].ToString());
              //  _informationList.Add(obj["TargerOperatingSystem"].ToString());
                _informationList.Add(obj["Version"].ToString());
            }

            return _informationList;
        }
    }

}

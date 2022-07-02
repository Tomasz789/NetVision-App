using NetVision.DataCore.PropertyUpdater;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.DataCore.Model
{
    public class NetworkInfoModel : INotifyPropertyChanged
    {
        private string id, name, desc, status, speed, physAddr;
        private List<string> gateways, dns, dhcp;
        public NetworkInfoModel()
        {
            gateways = new List<string>();
            dns = new List<string>();
            dhcp = new List<string>();
        }
        #region Properties
        /* public string Id { get; set; }
         public string Name { get; set; }

         public string Description { get; set; }

         public string Status { get; set; }

         public string PhysicalAddress { get; set; }
         public string Speed {get; set;}
         public List<string> GatewayAddresses { get; set; }
         public List<string> DnsAddresses { get; set; }*/

        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Description
        {
            get
            {
                return desc;
            }
            set
            {
                desc = value;
                OnPropertyChanged("Desc");
            }
        }

        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        public string PhysicalAddress
        {
            get
            {
                return physAddr;
            }
            set
            {
                physAddr = value;
                OnPropertyChanged("PhysicalAddress");
            }
        }
        public string Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
                OnPropertyChanged("Speed");
            }

        }
        public List<string> GatewayAddresses
        {
            get
            {
                return gateways;
            }
            set
            {
                gateways = value;
                OnPropertyChanged("Gateways");
            }
        }
        public List<string> DnsAddresses
        {
            get
            {
                return dns;
            }
            set
            {
                dns = value;
                OnPropertyChanged("Dns");
            }
        }


        public List<string> DhcpAddresses
        {
            get
            {
                return dhcp;
            }
            set
            {
                dhcp = value;
                OnPropertyChanged("Dhcp");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


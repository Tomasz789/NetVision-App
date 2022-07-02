using NetVision.DataCore.Model;
using NetVision.DataCore.PerformanceValueTypes;
using NetVision.Infrastructure.Services;
using NetVision.MVRelayCmds;
using NetVision.Updater;
using NetVision.ViewModel.MainViewModel;
using NetVision.ViewModel.PropertyUpdater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NetVision.ViewModel
{
    public class PerformanceValuesViewModel : AsyncViewModel
    {
        private IPerformanceService _service;

        private IList<PerformanceModel> _perfModelList = new List<PerformanceModel>();
        private PerformanceModel _model;
        private bool cpuInRange = false;

        public PerformanceValuesViewModel()
        {
            _service = new PerformanceService();
            _model = new PerformanceModel();
            // _perfModelList = new List<PerformanceModel>();
            /*foreach (var item in _service.GetPerformanceValues())
                _perfModelList.Add(item);*/
            AsyncCmd = new RelayCommand();
            //AsyncCmd.Execute(GetValues)
        }
      /*  public PerformanceModel GetModel()
        {
            return new PerformanceModel()
            {
                CPU_Usage = _service.CPU_MeasureUsage().Result,
                RAM_Available = _service.CPU_RAM_Available().Result,
                RAM_Current = _service.CPU_RAM_Current_Usage().Result,
                RAM_Total_Usage = _service.CPU_RAM_Total_Usage().Result
            };
        }
      */
       public float CPU_Usage
        {
            get
            {
                return _model.CPU_Usage;
            }
            set
            {
                _model.CPU_Usage = value;
                OnPropertyChanged("CPU");
            }
        }
        public float RAM_Total_Usage
        {
            get
            {
                return _model.RAM_Total_Usage;
            }
            set 
            {
                _model.RAM_Total_Usage = value;
                OnPropertyChanged("RAMTOTAL");
            }
        }

        public float RAM_Current
        {
            get
            {
                return _model.RAM_Current;
            }
            set
            {
                _model.RAM_Current = value;
                OnPropertyChanged("RAMCURRENT");
            }
        }

        public float RAM_Available
        {
            get
            {
                return _model.RAM_Available;
            }
            set
            {
                _model.RAM_Available = value;
                OnPropertyChanged("RAMAVAIL");
            }
        }
        public IList<PerformanceModel> PerformanceModelList
        {
            get
            {
                return _perfModelList;
            }
            set 
            {
                _perfModelList = value;
            }
        }
        public bool IsCPUInRange
        {
            get
            {
                return cpuInRange;
            }
            set
            {
                cpuInRange = value;
                OnPropertyChanged("IsCPUInRange");
            }
        }
        

        public ICommand AsyncCmd { get; set; }

        public void GetValues()
        {
            CPU_Usage =  _service.CPU_MeasureUsage().Result;
            RAM_Available = _service.RAM_Available().Result;
            RAM_Current = _service.RAM_Current_Usage().Result;
            RAM_Total_Usage = _service.RAM_Total_Usage().Result;
            SetAlarmValues(CPU_Usage);
        }

        private void SetAlarmValues(float cpu)
        {
            if(CPU_Usage >= 0)
            {
                cpuInRange = true;
            }
        }
    }
}

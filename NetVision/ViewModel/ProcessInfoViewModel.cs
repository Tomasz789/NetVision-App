using NetVision.DataCore.Model;
using NetVision.Infrastructure.Services;
using NetVision.MVRelayCmds;
using NetVision.ViewModel.PropertyUpdater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NetVision.ViewModel
{
    public class ProcessInfoViewModel : ViewModelPropertyUpdater
    {
        private int min, max;
        private IEnumerable<ProcessModel> procModel;
        private readonly IProcessInfoService _service;

        public ProcessInfoViewModel()
        {
            this.min = 0;
            this.max = 0;
            _service = new ProcessInfoService();
            procModel = _service.GetProcesses().AsEnumerable();    //get all process list
            SearchProcessesCmd = new RelayCommand(GetList, CanExecute);
        }

        public ICommand SearchProcessesCmd { get; set; }

        public int Min
        {
            get
            {
                return min;
            }
            set
            {
                min = value;
                OnPropertyChanged("Min");
            }
        }
        public int Max
        {
            get
            {
                return max;
            }
            set
            {
                max = value;
                OnPropertyChanged("Max");
            }
        }
        public IEnumerable<ProcessModel> ProcessList
        {
            get
            {
                return procModel;
            }
            set
            {
                procModel = value;
                OnPropertyChanged("ProcessList");
            }
        }

        public bool CanExecute(object parameter) { return true; }

        public void GetList(object param)
        {
            ProcessList = _service.SearchInIdRange(this.min, this.max, procModel);
        }

    }
}

using NetVision.DataCore.Model;
using NetVision.Infrastructure.Services;
using NetVision.MVRelayCmds;
using NetVision.Updater;
using NetVision.Utilities;
using NetVision.ViewModel.PropertyUpdater;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace NetVision.ViewModel
{
    public class TraceRouteViewModel : ViewModelPropertyUpdater, IDataErrorInfo
    {
        ITraceRouteService _service;
        private IList<TraceEntryModel> _traceList;
        private TraceEntryModel _traceModel = new TraceEntryModel();
        private ColorRandomizer _color = new ColorRandomizer();
        ObservableCollection<TraceEntryModel> _list = new ObservableCollection<TraceEntryModel>();
        public TraceRouteViewModel()
        {
            /*_traceList = new List<TraceEntryModel>(); 
            _traceModel = new TraceEntryModel()
            {
                Address = "www.google.com",
                HopCounter = 10,
                Timeout = 1000
            };*/
          /*  _traceModel = new TraceEntryModel()
            {
                Address = "www.facebook.com",
                HopCounter = 15,
                Timeout = 1500
            };*/
            _traceList = new List<TraceEntryModel>();
            _traceList.Add(_traceModel);

            _service = new TraceRouteService();
            GetTraceRouteCmd = new RelayCommand(GetTracert, CanExecute);

        }

        public string this[string name]
        {
            get
            {
                string err_type = null;
                switch (name)
                {
                    case "HostName":
                        {
                            if (string.IsNullOrEmpty(HostName))
                                err_type = "Host field cannot be empty!";
                        }
                        break;
                    case "Timeout":
                        {
                            if (string.IsNullOrEmpty(Timeout.ToString()))
                                err_type = "Timeout field is empty!";
                            if (Timeout <= 0)
                                err_type = "Timeout lower than 0 or equals 0!";
                            
                        }
                        break;
                }
                return err_type;
            }
        }

       
        public string Address
        {
            get
            {
                return _traceModel.Address.ToString();
              
            }
            set
            {
                _traceModel.Address = value;
                OnPropertyChanged("Address");
            }
        }

        public string HostName
        {
            get
            {
                return _traceModel.HostName;
            }
            set
            {
                _traceModel.HostName = value;
                OnPropertyChanged("HostName");
            }
        }

        public long Timeout
        {
            get
            {
                return _traceModel.Timeout;
            }
            set
            {
                _traceModel.Timeout = value;
                OnPropertyChanged("Timeout");
            }
        }

        public int HopCounter
        {
            get
            {
                return _traceModel.HopCounter;
            }
            set
            {
                _traceModel.HopCounter = value;
                OnPropertyChanged("HopCounter");
            }
        }

        public float AvgTimeout
        {
            get
            {
                return _traceModel.AvgTimeout;
            }
            set
            {
                _traceModel.AvgTimeout = value;
                OnPropertyChanged("AvgTimeout");
            }
        }

        public long MinTimeout
        {
            get
            {
                return _traceModel.MinTimeout;
            }
            set
            {
                _traceModel.AvgTimeout = value;
                OnPropertyChanged("MinTimeout");
            }
        }

        public long MaxTimeout
        {
            get
            {
                return _traceModel.MaxTimeout;
            }
            set
            {
                _traceModel.AvgTimeout = value;
                OnPropertyChanged("MaxTimeout");
            }
        }
        public Brush RectFill
        {
            get
            {
                return _color.GetRandomBrush();
            }
            set
            {
                
                OnPropertyChanged("RectFill");
            }
        }
        public TraceEntryModel Model
        {
            get
            {
                if (_traceModel == null)
                    throw new Exception("Model is null!");
                return _traceModel;
            }
            set
            {
                _traceModel = value;
            }
        }
        public IList<TraceEntryModel> TraceList
        {
            get
            {
                return _traceList;
                
            }
            set
            {
                _traceList = value;
            }
        }

        public ObservableCollection<TraceEntryModel> ObservableTraceList
        {
            get
            {
                return _list;

            }
            set
            {
                _list = value;
            }
        }
        public ICommand GetTraceRouteCmd { get; set; }

        public string Error => throw new NotImplementedException();

        public bool CanExecute(object parameter) { return true; }


        public async void GetTracert(object param)
        {
            _list = await _service.GetTraceEntriesAsync(_traceModel.HostName, _traceModel.Timeout, _traceModel.HopCounter); 
        }
       
    }
}

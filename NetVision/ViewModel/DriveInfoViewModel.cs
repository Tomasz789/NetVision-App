using LiveCharts;
using NetVision.DataCore.Model;
using NetVision.DataException.Exceptions;
using NetVision.Infrastructure.Services.HardwareServ;
using NetVision.ViewModel.PropertyUpdater;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.ViewModel
{
    public class DriveInfoViewModel : ViewModelPropertyUpdater
    {
        private readonly IDriveService _service = new DriveService();
        IList<DriveModel> _list;
        IList<DriveModel> _driveList = new List<DriveModel>();
        private DriveInfo _selectedDrive;
        private ChartValues<float> _totalSizeList;
        private ChartValues<float> _availableSizeList;

        public DriveInfoViewModel()
        {
            _driveList = new List<DriveModel>();
           // Task.Run(() => ProcessValues());
            //_selectedDrive = new DriveModel();
            _list = new List<DriveModel>();
            _totalSizeList = new ChartValues<float>();
            _availableSizeList = new ChartValues<float>();
        }

        public DriveInfo SelectedDrive
        {
            get
            {
                return _selectedDrive;
            }
            set
            {
                _selectedDrive = value;
            }
        }
        public IList<DriveModel> DriveModelList
        {
            get
            {
                if (_list == null)
                    throw new DataListNullException();
                return _list;

            }
            set
            {
                _list = value;
                OnPropertyChanged("DriveModelList");
            }
        }

        public string Name
        {
            get
            {
                return _selectedDrive.Name;
            }
            set
            {
                OnPropertyChanged("Name");
            }
        }
        public string Format
        {
            get
            {
                return _selectedDrive.DriveFormat;
            }
            set
            {
                OnPropertyChanged("Format");
            }
        }
        public long TotalSpace
        {
            get
            {
                return _selectedDrive.TotalSize;
            }
            set
            {
                OnPropertyChanged("TotalSpace");
            }
        }
        public long AvailableSpace
        {
            get
            {
                return _selectedDrive.AvailableFreeSpace;
            }
            set
            {
                OnPropertyChanged("AvailableSpace");
            }
        }
        public ChartValues<float> TotalSpaceList
        {
            get
            {
                if (_totalSizeList != null)
                    return _totalSizeList;
                else throw new Exception("Empty value list!");
            }
            set
            {
                _totalSizeList = value;
                OnPropertyChanged("TotalSizeList");
            }
        }

        public ChartValues<float> AvailableSpaceList
        {
            get
            {
                if (_availableSizeList != null)
                    return _availableSizeList;
                else throw new Exception("Empty value list!");
            }
            set
            {
                _availableSizeList = value;
                OnPropertyChanged("TotalSizeList");
            }
        }

        public async Task<DriveModel> GetSelectedDriveModel(string name)
        {
            _selectedDrive = await _service.GetCurrentDrive(name);
            _totalSizeList.Add(_selectedDrive.TotalSize);
            _availableSizeList.Add(_selectedDrive.AvailableFreeSpace);
            return new DriveModel()
            {
                Name = _selectedDrive.Name,
                Format = _selectedDrive.DriveFormat,
                TotalSpace = _selectedDrive.TotalSize,
                AvailableSpace = _selectedDrive.AvailableFreeSpace,
                Directory = _selectedDrive.RootDirectory.FullName
            };

           
        }
        public async Task ProcessValues()
        {
            var items =  _service.GetDrivers().Result;
            foreach (var dr in items)
            {
                _list.Add(new DriveModel()
                {
                    Name = dr.Name,
                    TotalSpace = dr.TotalSize,
                    AvailableSpace = dr.AvailableFreeSpace,
                    Directory = dr.RootDirectory.FullName,
                    Format = dr.DriveFormat.ToString()
                });

               
            }
            await Task.CompletedTask;
        }
    }
}

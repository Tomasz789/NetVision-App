using NetVision.MVRelayCmds;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NetVision.ViewModel.PropertyUpdater
{
    public class ViewModelPropertyUpdater : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand _cmd;

        public ICommand UpdateCommand
        {
            get
            {
                if (_cmd == null)
                    _cmd = new RelayCommand();
                return _cmd;
            }
            set
            {
                _cmd = value;
            }
        }
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

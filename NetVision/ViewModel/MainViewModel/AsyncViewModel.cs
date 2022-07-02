using NetVision.DataCore.PropertyUpdater;
using NetVision.MVRelayCmds;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NetVision.ViewModel.MainViewModel
{
    public class AsyncViewModel : UpdateProperty
    { 
        private ICommand _cmd;

        public ICommand UpdateCommand
        {
            get
            {
                if (_cmd == null)
                    _cmd = new AsyncRelayCommand();
                return _cmd;
            }
            set
            {
                _cmd = value;
            }
        }

    }
}

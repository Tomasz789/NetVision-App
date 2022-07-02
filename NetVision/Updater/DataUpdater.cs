using NetVision.MVRelayCmds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NetVision.Updater
{
    public class ViewModel
    {
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

    }
}

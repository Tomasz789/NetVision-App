using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.DataCore.PropertyUpdater
{
    /// <summary>
    /// Class implements INotifyProperyChanged interface - to update values of properties.
    /// </summary>
     public class UpdateProperty : INotifyPropertyChanged
     {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

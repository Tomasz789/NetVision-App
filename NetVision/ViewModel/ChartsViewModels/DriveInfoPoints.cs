using LiveCharts;
using NetVision.DataException.Exceptions;
using NetVision.ViewModel.PropertyUpdater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.ViewModel.ChartsViewModels
{
    /// <summary>
    /// View model class for updating drive memory values.
    /// </summary>
    public class DriveInfoPoints : ViewModelPropertyUpdater
    {
        private ChartValues<float> _values;

        public DriveInfoPoints()
        {
            _values = new ChartValues<float>();
        }

        public ChartValues<float> DriveSpaceValues
        {
            get
            {
                if (_values != null)
                    return _values;
                else throw new DataListNullException();
            }
            set
            {
                _values = value;
                
            }
        }
    }
}

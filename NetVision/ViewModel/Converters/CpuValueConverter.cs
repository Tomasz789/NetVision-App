using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NetVision.ViewModel.Converters
{
    public class CpuValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isCpuInRange = false;
            try
            {
                if ((float)value >= 0.0)
                {
                    isCpuInRange = true;
                }
            }
            catch (ArgumentException argEx)
            {
                isCpuInRange = false;
                throw new Exception(argEx.Message);
            }
            return isCpuInRange; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float cpuValue = 0;
            if (value is float single)
            {
                cpuValue = single;
            }
            return cpuValue;
        }
    }
}

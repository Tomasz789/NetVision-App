using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NetVision.ViewModel.Converters
{
    public class Converter<T> : IValueConverter
    {
        #region methods of IValueConverter interface
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion

        private bool CheckIfValueInRange(T @object, object currentValue, float rangeValue)
        {
            bool isInRange = false;

            return isInRange;
        }
    }
}

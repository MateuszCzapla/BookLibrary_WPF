using System;
using System.Windows.Data;

namespace BookLibrary.Views.Converters
{
    public class StringToShortConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //return value;
            return System.Convert.ToInt16(value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //if ((short)value == 0) return String.Empty;
            if ((short)value == 0) return String.Empty;
            return value.ToString();
        }
    }
}

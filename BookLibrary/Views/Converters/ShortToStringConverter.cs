using System;
using System.Windows.Data;

namespace BookLibrary.Views.Converters
{
    public class ShortToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((short)value == 0) return String.Empty;
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.Equals(String.Empty)) return 0;
            return System.Convert.ToInt16(value);
        }
    }
}

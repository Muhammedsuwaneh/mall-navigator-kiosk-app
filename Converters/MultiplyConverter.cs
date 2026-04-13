using System.Globalization;
using System.Windows.Data;

namespace MallMapKiosk.Converters
{
    public class MultiplyConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2)
                return 0;

            if (values[0] is double relative && values[1] is double size)
                return relative * size;

            return 0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

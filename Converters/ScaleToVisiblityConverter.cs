using MallMapKiosk.ViewModels;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MallMapKiosk.Converters
{
    public class ScaleToVisiblityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var scale = value.ToString()!;

            if (Enum.Parse<Scaling>(scale) == Scaling.FullScreen)
            {
                return Visibility.Collapsed;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

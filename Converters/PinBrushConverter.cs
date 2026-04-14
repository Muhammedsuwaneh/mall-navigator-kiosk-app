using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MallMapKiosk.Converters
{
    public class PinBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string category = value.ToString()!;

            return category switch
            {
                "Stores" => GetBrush("#2B7FFF"),
                "DiningRoom" => GetBrush("#F54927"),
                "RestRoom" => GetBrush("#45556C"),
                "EmergencyExit" => GetBrush("#FF2056"),
                "Leisure" => GetBrush("#2D9966"), 
                _ => GetBrush("#45556C")
            };
        }

        private SolidColorBrush GetBrush(string colorString) => new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorString));

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

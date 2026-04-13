using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MallMapKiosk.Converters
{
    public class PinIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string category = value.ToString()!;

            return category switch
            {
                "Stores" => new BitmapImage(new Uri("pack://application:,,,/Assets/Images/stores_pin.png")),
                "DiningRoom" => new BitmapImage(new Uri("pack://application:,,,/Assets/Images/dining_pin.png")),
                "RestRoom" => new BitmapImage(new Uri("pack://application:,,,/Assets/Images/restroom_pin.png")),
                "EmergencyExit" => new BitmapImage(new Uri("pack://application:,,,/Assets/Images/exits.png")),
                _ => null   
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

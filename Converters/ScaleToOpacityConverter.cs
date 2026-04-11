using MallMapKiosk.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace MallMapKiosk.Converters
{
    public class ScaleToOpacityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Scaling scale && parameter is string param)
            {
                if (Enum.TryParse<Scaling>(param, out var _scale))
                {
                    return scale == _scale ? .8 : .5;
                }
            }

            return .5;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

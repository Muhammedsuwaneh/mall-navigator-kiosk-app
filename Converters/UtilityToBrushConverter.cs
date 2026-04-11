using MallMapKiosk.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace MallMapKiosk.Converters
{
    public class UtilityToBrushConverter : IValueConverter
    {
        public Brush ActiveBrush { get; set; } = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#69DFFA"));

        public Brush InactiveBrush { get; set; } = Brushes.Transparent;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Utility utility && parameter is string param)
            {
                if (Enum.TryParse<Utility>(param, out var _utility))
                {
                    return utility == _utility ? ActiveBrush : InactiveBrush;
                }
            }

            return InactiveBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

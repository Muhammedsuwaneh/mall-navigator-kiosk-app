using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using MallMapKiosk.ViewModels;

namespace MallMapKiosk.Converters
{
    public class LanguageToBrushConverter : IValueConverter
    {
        public Brush ActiveBrush { get; set; } =
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#69DFFA"));

        public Brush InactiveBrush { get; set; } =
            Brushes.Transparent;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is AppLanguage selected && parameter is string param)
            {
                if (Enum.TryParse<AppLanguage>(param, out var lang))
                {
                    return selected == lang ? ActiveBrush : InactiveBrush;
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
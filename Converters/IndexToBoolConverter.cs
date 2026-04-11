using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows;

namespace MallMapKiosk.Converters
{
    public class IndexToBoolConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length < 3)
                return false;

            var itemsControl = values[0] as ItemsControl;
            var container = values[1] as DependencyObject;
            var currentIndex = values[2];

            if (itemsControl == null || container == null || currentIndex == null)
                return false;

            int index = itemsControl.ItemContainerGenerator.IndexFromContainer(container);

            return index == System.Convert.ToInt32(currentIndex);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
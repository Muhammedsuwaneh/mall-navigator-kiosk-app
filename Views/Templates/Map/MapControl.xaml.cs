using MallMapKiosk.ViewModels.Contracts;
using System.Windows;
using System.Windows.Controls;

namespace MallMapKiosk.Views.Templates.Map
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class MapControl : UserControl
    {
        public MapControl()
        {
            InitializeComponent();
        }

        private double _zoom = 1.0;
        private const double ZoomStep = 0.2;
        private const double MaxZoom = 3.0;
        private const double MinZoom = 0.5;

        private void ZoomIn_Click(object sender, RoutedEventArgs e)
        {
            if (_zoom < MaxZoom)
            {
                _zoom += ZoomStep;
                MapScaleTransform.ScaleX = _zoom;
                MapScaleTransform.ScaleY = _zoom;
            }
        }

        private void ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            if (_zoom > MinZoom)
            {
                _zoom -= ZoomStep;
                MapScaleTransform.ScaleX = _zoom;
                MapScaleTransform.ScaleY = _zoom;
            }
        }
    }
}

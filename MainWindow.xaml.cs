using MallMapKiosk.Common.Utilities;
using MallMapKiosk.Common.Window;
using MallMapKiosk.Views.Pages;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Input;

namespace MallMapKiosk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HotKey HotkeyAppExit { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.Closed += (_, _) => System.Environment.Exit(0);

            Loaded += MainWindow_Loaded;
            PreviewKeyDown += MainWindow_PreviewKeyDown;
            RegisterHotKeyAppExit(Key.Escape);

            //Cursor = Cursors.None; // hide mouse cursor

            AudioController.PlaySound();
        }

        /// <summary>
        /// kiosk mode - disable close keys - esc works as app exit key, alt+f4 and windows key are disabled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.System || e.Key == Key.F4)
            {
                e.Handled = true;
            }

            base.OnPreviewKeyDown(e);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e) => NavigationFrame.Navigate(App.AppHost!.Services.GetRequiredService<Main>());

        private void RegisterHotKeyAppExit(Key Key)
        {
            if (HotkeyAppExit != null) return;
            HotkeyAppExit = new HotKey(ModifierKeys.None, Key, Application.Current.MainWindow);
            HotkeyAppExit.HotKeyPressed += (hotkey) =>
            {
                TaskBar.ShowTaskbar();
                System.Environment.Exit(0);
            };
        }
    }
}
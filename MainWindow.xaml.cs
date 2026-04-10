using MallMapKiosk.Common.Utilities;
using MallMapKiosk.Common.Window;
using MallMapKiosk.Views.Pages;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        RegisterHotKeyAppExit(Key.Escape);
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        LanguageUtility.ToggleApplicationLanguage(this, "en");
        NavigationFrame.Navigate(App.AppHost!.Services.GetRequiredService<Main>());
    }
 

    private void RegisterHotKeyAppExit(Key Key) 
    {           
         if (HotkeyAppExit != null) return; 
         HotkeyAppExit = new HotKey(ModifierKeys.None, Key, Application.Current.MainWindow); 
         HotkeyAppExit.HotKeyPressed += (hotkey) => System.Environment.Exit(0); }
    }
}
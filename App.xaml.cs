using MallMapKiosk.Common.Utilities;
using MallMapKiosk.ViewModels;
using MallMapKiosk.ViewModels.Contracts;
using MallMapKiosk.Views.Pages;
using MallMapKiosk.Views.Templates.Map;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace MallMapKiosk
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }
        public App()
        {
            AppHost =  Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                {
                    services.AddTransient<IMainViewModel, MainViewModel>();
                    services.AddTransient<Main>();
                    services.AddSingleton<MainWindow>();
                })
                .Build();

        }

        protected async override void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            LanguageUtility.ToggleApplicationLanguage("en");

            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }


        protected async override void OnExit(ExitEventArgs e)
        {
            if (AppHost != null)
            {
                await AppHost.StopAsync();
                AppHost.Dispose();
            }
            base.OnExit(e);
        }
    }
}

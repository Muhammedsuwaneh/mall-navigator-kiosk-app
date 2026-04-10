using System.Globalization;
using System.Windows.Input;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace MallMapKiosk.Common.Utilities
{
    public sealed class LanguageUtility
    {
        private static string ApplicationtLanguageCode = "";

        public static void ToggleApplicationLanguage(string languageCode)
        {
            if (languageCode == ApplicationtLanguageCode) return;

            ApplicationtLanguageCode = languageCode;

            ResourceDictionary dictionary = new ResourceDictionary();

            switch (languageCode)
            {
                case "en":
                    dictionary.Source = new Uri("..\\Language\\Strings\\Lang.en.xaml", UriKind.Relative);
                    break;
                case "tr":
                    dictionary.Source = new Uri("..\\Language\\Strings\\Lang.tr.xaml", UriKind.Relative);
                    break;
                case "ar":
                    dictionary.Source = new Uri("..\\Language\\Strings\\Lang.ar.xaml", UriKind.Relative);
                    break;
                default:
                    dictionary.Source = new Uri("..\\Language\\Strings\\Lang.en.xaml", UriKind.Relative);
                    break;
            }

            var suffix = (languageCode == "en") ? "US" : languageCode.ToUpper();
            var culture = new CultureInfo($"{languageCode}-{suffix}");

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            InputLanguageManager.Current.CurrentInputLanguage = culture;

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
        }
    }
}

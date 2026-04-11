using MallMapKiosk.Commands;
using MallMapKiosk.Commands.Utilities;
using MallMapKiosk.Common.Utilities;
using MallMapKiosk.ViewModels.Contracts;
using MallMapKiosk.Views.Templates.Map;
using MallMapKiosk.Views.Templates.Menu;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MallMapKiosk.ViewModels
{
    public enum AppLanguage { EN, TR, AR }
    public enum Utilities { Stores, DiningRoom, Toilet, EmergencyExit }
    public enum Scaling { ZoomIn, ZoomOut, FullScreen }

    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        public ObservableCollection<string> Media { get; set; } = new()
        {
            "media_1.mp4",
            "media_2.mp4",
            "media_3.mp4",
            "media_4.mp4"
        };

        private int _currentMediaIndex = 0;
        public int CurrentMediaIndex
        {
            get => _currentMediaIndex;
            set
            {
                if (_currentMediaIndex != value)
                {
                    _currentMediaIndex = value;
                    OnPropertyChanged(nameof(CurrentMediaIndex));
                }
            }
        }

        private AppLanguage _selectedLanguage = AppLanguage.EN;
        public AppLanguage SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                if (_selectedLanguage != value)
                {
                    _selectedLanguage = value;
                    OnPropertyChanged(nameof(SelectedLanguage));
                }
            }
        }

        private Scaling _scaling = Scaling.ZoomIn;
        public Scaling Scaling
        {
            get => _scaling;
            set
            {
                if (_scaling != value)
                {
                    _scaling = value;
                    OnPropertyChanged(nameof(Scaling));
                }
            }
        }

        private string _videoPath = string.Empty;
        public string VideoPath
        {
            get => _videoPath; 
            set
            {
                if(_videoPath != value)
                {
                    _videoPath = value;
                    OnPropertyChanged(nameof(VideoPath));
                }
            }
        }

        private ICommand _mediaEndedCommand;
        public ICommand MediaEndedCommand
        {
            get
            {
                if (_mediaEndedCommand == null)
                    _mediaEndedCommand = new RelayCommand<object>(OnMediaEnded);

                return _mediaEndedCommand;
            }
        }

        private ICommand _languageButtonCommand;
        public ICommand LanguageButtonCommand
        {
            get
            {
                if(_languageButtonCommand == null)
                    _languageButtonCommand = new RelayCommand<string>(OnLanguageButtonTouched);
                
                return _languageButtonCommand;
            }
        }

        private ICommand _scaleButtonCommand;
        public ICommand ScaleButtonCommand
        {
            get
            {

               if(_scaleButtonCommand == null)
                    _scaleButtonCommand = new RelayCommand<string>(OnScaleButtonTouched);

                return _scaleButtonCommand;
            }   }

        private void OnScaleButtonTouched(string param)
        {
            Scaling = Enum.Parse<Scaling>(param);

            /*switch ()
            {
               
            }*/
        }
    

        private void OnLanguageButtonTouched(string param)
        {
            if(SelectedLanguage.ToString() == param)
                return; 

            SelectedLanguage = Enum.Parse<AppLanguage>(param);
            LanguageUtility.ToggleApplicationLanguage(param.ToLower());
        }

        private void OnMediaEnded(object obj)
        {
            if(_currentMediaIndex == Media.Count - 1)
               CurrentMediaIndex = 0;
            else
               CurrentMediaIndex++;

            VideoPath = FileRetriever.GetFile("assets\\", Media[_currentMediaIndex]);
            OnPropertyChanged(nameof(CurrentMediaIndex));
        }

        public MainViewModel() => InitializeViewModel();

        private void InitializeViewModel()
        {
            _videoPath = FileRetriever.GetFile("assets\\", Media[_currentMediaIndex]);
        }
    }
}

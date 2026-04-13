using MallMapKiosk.Commands;
using MallMapKiosk.Commands.Utilities;
using MallMapKiosk.Common.Utilities;
using MallMapKiosk.Models;
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
    public enum Utility { None, Stores, DiningRoom, RestRoom, EmergencyExit }
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

        
        public MainViewModel() => InitializeViewModel();

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
                if (_videoPath != value)
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
                if (_languageButtonCommand == null)
                    _languageButtonCommand = new RelayCommand<string>(OnLanguageButtonTouched);

                return _languageButtonCommand;
            }
        }

        private ICommand _scaleButtonCommand;
        public ICommand ScaleButtonCommand
        {
            get
            {

                if (_scaleButtonCommand == null)
                    _scaleButtonCommand = new RelayCommand<string>(OnScaleButtonTouched);

                return _scaleButtonCommand;
            } 
        }


        private Utility _menuUtility;
        public Utility MenuUtility
        {
            get => _menuUtility;
            set
            {
                if (_menuUtility != value)
                {
                    _menuUtility = value;
                    OnPropertyChanged(nameof(MenuUtility));
                }
            }
        }

        private ICommand _menuButtonCommand;
        public ICommand MenuButtonCommand
        {
            get
            {
                if(_menuButtonCommand == null)
                    _menuButtonCommand = new RelayCommand<string>(OnMenuButtonTouched);

                return _menuButtonCommand;  
            }
        }

        private void OnMenuButtonTouched(string param)
        {
            if(param == MenuUtility.ToString())
            {
                MenuUtility = 0; 
                VisiblePins.Clear();
                return;
            }

            MenuUtility = Enum.Parse<Utility>(param);
            UpdateVisiblePins();
        }

        private void OnScaleButtonTouched(string param)
        {
            Scaling = Enum.Parse<Scaling>(param);

            switch (Scaling)
            {
               case Scaling.ZoomIn:
                    ZoomIn();
                    break;
                case Scaling.ZoomOut:
                    ZoomOut();
                    break;
                case Scaling.FullScreen:
                    FullScreen();
                    break;
            }
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


        #region Pins
        public ObservableCollection<MapPin> VisiblePins { get; set; } = new();

        private List<MapPin> _allPins = new();

        private void InitializeViewModel()
        {
            _videoPath = FileRetriever.GetFile("assets\\", Media[_currentMediaIndex]);
            InitPins();
        }

        private void InitPins()
        {
            _allPins = new List<MapPin>
            {
                // STORES
                new MapPin { X = 0, Y = 0, Category = "Stores", Name = "Store 1" },
                new MapPin { X = 0, Y = 0, Category = "Stores", Name = "Store 2" },
                new MapPin { X = 0, Y = 0, Category = "Stores", Name = "Store 3" },
                new MapPin { X = 0, Y = 0, Category = "Stores", Name = "Store 4" },
                new MapPin { X = 0, Y = 0, Category = "Stores", Name = "Store 5" },
                new MapPin { X = 0, Y = 0, Category = "Stores", Name = "Store 6" },
                new MapPin { X = 0, Y = 0, Category = "Stores", Name = "Store 7" },
                new MapPin { X = 0, Y = 0, Category = "Stores", Name = "Store 8" },
                new MapPin { X = 0, Y = 0, Category = "Stores", Name = "Store 9" },
                new MapPin { X = 0, Y = 0, Category = "Stores", Name = "Store 10" },
                new MapPin { X = 0, Y = 0, Category = "Stores", Name = "Store 11" },
                new MapPin { X = 0, Y = 0, Category = "Stores", Name = "Store 12" },
                new MapPin { X = 0, Y = 0, Category = "Stores", Name = "Store 13" },
                new MapPin { X = 0, Y = 0, Category = "Stores", Name = "Store 14" },
                new MapPin { X = 0, Y = 0, Category = "Stores", Name = "Store 15" },

                // DINING - done
                new MapPin { X = 0.3, Y = 0.6, Category = "DiningRoom", Name = "" },
                new MapPin { X = 0.6, Y = 0.4, Category = "DiningRoom", Name = "" },
                new MapPin { X = 0.27, Y = 0.67, Category = "DiningRoom", Name = "Kebab\nSpot" },
                new MapPin { X = 0.3, Y = 0.7, Category = "DiningRoom", Name = "Crunchy\nChicken" },
                new MapPin { X = 0.31, Y = 0.7, Category = "DiningRoom", Name = "Starbucks" },
                new MapPin { X = 0.37, Y = 0.7, Category = "DiningRoom", Name = "Rusty Pub" },
                new MapPin { X = 0.49, Y = 0.7, Category = "DiningRoom", Name = "PizzaHot" },
                new MapPin { X = 0.52, Y = 0.7, Category = "DiningRoom", Name = "Popeyes" },
                new MapPin { X = 0.55, Y = 0.7, Category = "DiningRoom", Name = "KFC" },
                new MapPin { X = 0.59, Y = 0.7, Category = "DiningRoom", Name = "McDonalds" },
                new MapPin { X = 0.63, Y = 0.7, Category = "DiningRoom", Name = "  Dennis\nDines" },
                                 
                // RESTROOMS - done
                new MapPin { X = 0.85, Y = 0.03, Category = "RestRoom", Name = "" },
                new MapPin { X = 0.83, Y = 0.6, Category = "RestRoom", Name = "" },
                new MapPin { X = 0.75, Y = 0.8, Category = "RestRoom", Name = "" },
                new MapPin { X = 0.21, Y = 0.35, Category = "RestRoom", Name = "" },
                new MapPin { X = 0.14, Y = 0.4, Category = "RestRoom", Name = "" },
                new MapPin { X = 0.18, Y = 0.71, Category = "RestRoom", Name = "" },

                // EXITS - done
                new MapPin { X = 0.5, Y = 0.07, Category = "EmergencyExit", Name = "" },
                new MapPin { X = 0.22, Y = 0.7, Category = "EmergencyExit", Name = "" },
                new MapPin { X = 0.7, Y = 0.8, Category = "EmergencyExit", Name = "" },
            };

            UpdateVisiblePins();
        }

        private void UpdateVisiblePins()
        {
            VisiblePins.Clear();

            if (MenuUtility == Utility.None)
                return;

            string category = MenuUtility.ToString();

            var pins = _allPins.Where(p => p.Category == category);

            foreach (var pin in pins)
                VisiblePins.Add(pin);
        }

        #endregion

        #region Scaling 

        private double _zoom = 1.0;
        private const double ZoomStep = 0.1;
        private const double MaxZoom = 1.05;
        private const double MinZoom = 0.8;


        private double _scaleX = 1.0;
        public double ScaleX
        {
            get => _scaleX;
            set
            {
                if(_scaleX != value)
                {
                    _scaleX = value;
                    OnPropertyChanged(nameof(ScaleX));
                }
            }
        }

        private double _scaleY = 1.0;
        public double ScaleY
        {
            get => _scaleY;
            set
            {
                if (_scaleY != value)
                {
                    _scaleY = value;
                    OnPropertyChanged(nameof(ScaleY));
                }
            }
        }

        private void ZoomIn()
        {
            if (_zoom < MaxZoom)
            {
                _zoom += ZoomStep;
                ScaleX = _zoom;
                ScaleY = _zoom;
            }
        }

        private void ZoomOut()
        {
            if (_zoom > MinZoom)
            {
                _zoom -= ZoomStep;
                ScaleX = _zoom;
                ScaleY = _zoom;
            }
        }

        private void FullScreen()
        {
            
        }
        #endregion
    }
}

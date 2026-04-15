using MallMapKiosk.Commands;
using MallMapKiosk.Commands.Utilities;
using MallMapKiosk.Common.Utilities;
using MallMapKiosk.Models;
using MallMapKiosk.ViewModels.Contracts;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MallMapKiosk.ViewModels
{
    public enum AppLanguage { EN, TR, AR }
    public enum Utility { None, Stores, DiningRoom, RestRoom, EmergencyExit, Leisure }
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


        #region Info Card
        private ICommand _pinCommand;
        public ICommand PinCommand
        {
            get
            {
                if(_pinCommand == null) 
                    _pinCommand = new RelayCommand<int>((Id) =>
                    {
                        SelectedPin = DataLayer.allPins.FirstOrDefault(p => p.Id == Id)!;

                        if (SelectedPin == null)
                        {
                            MessageBox.Show("Utility data not found ....");
                            return;
                        }


                        CardX = SelectedPin.X * 1500;
                        CardY = SelectedPin.Y * 600;
                        ShowCard = true;
                    });

                return _pinCommand;
            }
        }

        private ICommand _closeCardCommand;
        public ICommand CloseCardCommand
        {
            get
            {
                if (_closeCardCommand == null)
                    _closeCardCommand = new RelayCommand<object>((obj) =>
                    {
                        ShowCard = false;
                    });

                return _closeCardCommand;
            }
        }

        private bool _showCard = false;
        public bool ShowCard
        {
            get => _showCard;
            set
            {
                if (_showCard != value)
                {
                    _showCard = value;
                    OnPropertyChanged(nameof(ShowCard));
                }
            }
        }

        private MapPin _selectedPin;
        public MapPin SelectedPin
        {
            get => _selectedPin;
            set
            {
                if (_selectedPin != value)
                {
                    _selectedPin = value;
                    OnPropertyChanged(nameof(SelectedPin));

                    ShowCard = _selectedPin != null;
                }
            }
        }

        private double _cardX;
        public double CardX
        {
            get => _cardX;
            set
            {
                _cardX = value;
                OnPropertyChanged(nameof(CardX));
            }
        }

        private double _cardY;
        public double CardY
        {
            get => _cardY;
            set
            {
                _cardY = value;
                OnPropertyChanged(nameof(CardY));
            }
        }

        #endregion

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
                restore();
                return;
            }

            MenuUtility = Enum.Parse<Utility>(param);
            UpdateVisiblePins();
        }

        private void OnScaleButtonTouched(string param)
        {
            if(param == "FullScreen" && Scaling == Scaling.FullScreen)
            {
                // exit full screen
                Scaling = Scaling.ZoomIn;
                ExitFullScreen();
                return;
            }
            else
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
        }

        private void OnLanguageButtonTouched(string param)
        {
            if(SelectedLanguage.ToString() == param)
                return; 

            SelectedLanguage = Enum.Parse<AppLanguage>(param);
            LanguageUtility.ToggleApplicationLanguage(param.ToLower());

            DataLayer.InitPins(SelectedLanguage);
            UpdateVisiblePins();
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

        public ObservableCollection<MapPin> VisiblePins { get; set; } = new();


        private void InitializeViewModel()
        {
            _videoPath = FileRetriever.GetFile("assets\\", Media[_currentMediaIndex]);
            DataLayer.InitPins(SelectedLanguage);
            UpdateVisiblePins();
        }

        private void UpdateVisiblePins()
        {
            if (MenuUtility == Utility.None)
            {
                restore();
                return;
            }

            VisiblePins.Clear();
            string category = MenuUtility.ToString();

            var pins = DataLayer.allPins.Where(p => p.Category == category);

            foreach (var pin in pins)
                VisiblePins.Add(pin);
        }

        private void restore()
        {
            VisiblePins.Clear();

            foreach (var pin in DataLayer.allPins)
                VisiblePins.Add(pin);
        }

        #region Scaling 

        private double _zoom = 1.0;
        private const double ZoomStep = 0.1;
        private const double MaxZoom = 1.05;
        private const double MinZoom = 0.8;

        private double row = 3;
        public double Row
        {
            get => row;
            set
            {
                if (row != value)
                {
                    row = value;
                    OnPropertyChanged(nameof(Row));
                }
            }
        }

        private double rowSpan = 1;
        public double RowSpan
        {
            get => rowSpan;
            set
            {
                if (rowSpan != value)
                {
                    rowSpan = value;
                    OnPropertyChanged(nameof(RowSpan));
                }
            }
        }

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

        private void FullScreen()
        {
            _zoom += ZoomStep * 1.2;
            ScaleX = _zoom;
            ScaleY = _zoom;
            row = 1;
            rowSpan = 4;
        }

        private void ExitFullScreen()
        {
            _zoom = 1.0;
            ScaleX = _zoom;
            ScaleY = _zoom;
            row = 3;
            rowSpan = 1;
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

        #endregion

        #region Search Filter

        public ObservableCollection<MapPin> FilteredPins { get; set; } = new();

        private bool _filtered = false;
        public bool Filtered
        {
            get => _filtered;
            set
            {
                if (_filtered != value)
                {
                    _filtered = value;
                    OnPropertyChanged(nameof(Filtered));
                }
            }
        }

        private bool _empty = true;
        public bool EmptyParam
        {
            get => _empty;
            set
            {
                if (_empty != value)
                {
                    _empty = value;
                    OnPropertyChanged(nameof(EmptyParam));
                }
            }
        }

        private string _searchParam = "";
        public string SearchParam
        {
            get => _searchParam;
            set
            {
                if (_searchParam != value)
                {
                    _searchParam = value;
                    OnPropertyChanged(nameof(SearchParam));
                    OnSearchChanged();
                }
            }
        }

        private void OnSearchChanged()
        {
            if (MenuUtility != Utility.None) MenuUtility = Utility.None; // remove any active category

            VisiblePins.Clear();
            EmptyParam = string.IsNullOrWhiteSpace(_searchParam); // hide placeholder

            if(EmptyParam)
            {
                FilteredPins.Clear();
                Filtered = false;
                return;
            }

            // filter common utilities
            var filtered = DataLayer.allPins.Where(p => p.Name.Contains(_searchParam, StringComparison.InvariantCultureIgnoreCase)).ToList();

            Filtered = filtered.Count() > 0;
            FilteredPins.Clear();

            if(filtered.Count() > 0)
            {
                foreach (var pin in filtered)
                {
                    FilteredPins.Add(pin);
                }
            }
        }


        private ICommand _closeSearchDialogCommand;
        public ICommand CloseSearchDialogCommand
        {
            get
            {
                if (_closeSearchDialogCommand == null)
                    _closeSearchDialogCommand = new RelayCommand<object>(OnCloseSearchDialog);
                return _closeSearchDialogCommand;
            }
        }

        private void OnCloseSearchDialog(object obj)
        {
            SearchParam = "";
            Filtered = false;
        }

        private ICommand _filteredItemCommand;
        public ICommand FilteredItemCommand
        {
            get
            {
                if(_filteredItemCommand == null)
                    _filteredItemCommand = new RelayCommand<string>(OnFilteredItemSelected);
                return _filteredItemCommand;
            }
        }

        private void OnFilteredItemSelected(string utility)
        {
            VisiblePins.Clear();
            var selectedPin = DataLayer.allPins.FirstOrDefault(p => p.Name == utility);

            if (selectedPin != null)
            {
                VisiblePins.Add(selectedPin);
                MenuUtility = Enum.Parse<Utility>(selectedPin.Category);
            }
        }

        #endregion
    }
}

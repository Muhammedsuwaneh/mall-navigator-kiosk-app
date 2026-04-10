using MallMapKiosk.Commands;
using MallMapKiosk.Commands.Utilities;
using MallMapKiosk.Common.Utilities;
using MallMapKiosk.ViewModels.Contracts;
using MallMapKiosk.Views.Templates.Map;
using MallMapKiosk.Views.Templates.Menu;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MallMapKiosk.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private int _currentMediaIndex = 0;
        private List<string> _media = new() { "media_1.mp4", "media_2.mp4" };

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

        private void OnMediaEnded(object obj)
        {
            if(_currentMediaIndex == _media.Count - 1)
                _currentMediaIndex = 0;
            else
                _currentMediaIndex++;

            VideoPath = FileRetriever.GetFile("assets\\", _media[_currentMediaIndex]);
        }

        public MainViewModel() => InitializeViewModel();

        private void InitializeViewModel()
        {
            _videoPath = FileRetriever.GetFile("assets\\", _media[_currentMediaIndex]);
        }
    }
}

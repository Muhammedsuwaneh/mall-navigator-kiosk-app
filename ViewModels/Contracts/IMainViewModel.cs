using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MallMapKiosk.ViewModels.Contracts
{
    public interface IMainViewModel
    {
        public ICommand MediaEndedCommand { get; }
    }
}

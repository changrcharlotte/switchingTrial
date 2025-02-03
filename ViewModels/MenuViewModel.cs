using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace switchingTrial.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public ICommand NavigateGameCommand { get; }

        public MenuViewModel(INavigationService GameNavigationService)
        {
            NavigateGameCommand = new NavigateCommand(GameNavigationService);
        }
    }
}
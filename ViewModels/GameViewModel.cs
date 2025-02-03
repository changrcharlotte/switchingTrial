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
    public class GameViewModel : ViewModelBase
    {
        public ICommand NavigateMenuCommand { get; }

        public GameViewModel(INavigationService MenuNavigationService)
        {
            NavigateMenuCommand = new NavigateCommand(MenuNavigationService);
        }
    }
}
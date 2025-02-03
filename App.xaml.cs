using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;
using switchingTrial.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace switchingTrial
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public App()
        {
            _navigationStore = new NavigationStore();
            _modalNavigationStore = new ModalNavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService navigationService = CreateMenuNavigationService();
            navigationService.Navigate();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore, _modalNavigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private INavigationService CreateMenuNavigationService()//chain of events :), so that it shows up 
        {
            return new NavigationService<MenuViewModel>(_navigationStore, CreateMenuViewModel);
        }

        private MenuViewModel CreateMenuViewModel()
        {
            return new MenuViewModel(CreateGameNavigationService());
        }

        private INavigationService CreateGameNavigationService()
        {
            return new NavigationService<GameViewModel>(_navigationStore, CreateGameViewModel);
        }

        private GameViewModel CreateGameViewModel()
        {
            return new GameViewModel(CreateMenuNavigationService());
        }
    }

}

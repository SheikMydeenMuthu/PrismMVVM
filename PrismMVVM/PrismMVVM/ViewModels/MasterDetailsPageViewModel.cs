using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismMVVM.Model;
using PrismMVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PrismMVVM.ViewModels
{
    public class MasterDetailsPageViewModel : ViewModelBase
    {
        public DelegateCommand NavigateCommand { get; set; }
        public ObservableCollection<MyMenuItem> MenuItems { get; set; }

        private INavigationService _navigationService;

        private MyMenuItem selectedMenuItem;
        public MyMenuItem SelectedMenuItem
        {
            get => selectedMenuItem;
            set => SetProperty(ref selectedMenuItem, value);
        }
        public MasterDetailsPageViewModel(INavigationService navigationService):base(navigationService)
        {
            _navigationService = navigationService;

            MenuItems = new ObservableCollection<MyMenuItem>();

            MenuItems.Add(new MyMenuItem()
            {
                Icon = "ic_launcher.png",
                PageName = nameof(LoginPage),
                Title = "Login"
            });
            MenuItems.Add(new MyMenuItem()
            {
                Icon = "ic_launcher.png",
                PageName = nameof(MainPage),
                Title = "Main Page"
            });

            MenuItems.Add(new MyMenuItem()
            {
                Icon = "ic_launcher.png",
                PageName = nameof(SecondPage),
                Title = "SecondPage"
            });

            NavigateCommand = new DelegateCommand(NavigateToPage);
        }

       
        internal async void NavigateToPage()
        {
            await _navigationService.NavigateAsync("NavigationPage/" + SelectedMenuItem.PageName);
        }

    }
}

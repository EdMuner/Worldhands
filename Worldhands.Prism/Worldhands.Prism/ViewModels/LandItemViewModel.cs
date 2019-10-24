using Xamarin.Forms;
using Prism.Commands;
using Prism.Navigation;
using Worldhands.Common.Models;
using Worldhands.Prism.Views;
using System;

namespace Worldhands.Prism.ViewModels
{
    public class LandItemViewModel : LandResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectLandCommand;

        public LandItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectLandCommand => _selectLandCommand ?? (_selectLandCommand = new DelegateCommand(SelectLand));

        private async void SelectLand()
        {
            var parameters = new NavigationParameters
            {
                { "land", this}
            };
            await _navigationService.NavigateAsync("LandTabbedPage", parameters);
        }
    }
}

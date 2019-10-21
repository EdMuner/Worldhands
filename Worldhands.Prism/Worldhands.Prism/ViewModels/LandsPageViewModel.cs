using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Worldhands.Common.ModelsLand;
using Worldhands.Common.ServicesLand;

namespace Worldhands.Prism.ViewModels
{
    public class LandsPageViewModel : ViewModelBase
    {
        private ApiServiceLand _apiService;
        private ObservableCollection<Land> _lands;

        public LandsPageViewModel(
            INavigationService navigationService,
            ApiServiceLand apiService) : base(navigationService)
        {
            _apiService = new ApiServiceLand();
            Title = "Lands";
            LoadLands();
        }

        public ObservableCollection<Land> Lands
        {
            get => _lands;
            set => SetProperty(ref _lands, value);
        }


        private async void LoadLands()
        {
            var response = await _apiService.GetList<Land>(
               "https://restcountries.eu",
                "/rest",
                "/v2/all");

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
            }
            var list = (List<Land>)response.Result;
            Lands = new ObservableCollection<Land>(list);
        }
    }
}

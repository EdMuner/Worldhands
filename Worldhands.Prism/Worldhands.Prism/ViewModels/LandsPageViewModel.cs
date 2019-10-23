using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Worldhands.Common.Models;
using Worldhands.Common.Services;

namespace Worldhands.Prism.ViewModels
{
    public class LandsPageViewModel : ViewModelBase
    {
        private ApiService _apiService;
        private ObservableCollection<Land> _lands;
        private bool _isRunning;
        private bool _isEnabled;
        private bool _isRefreshing;


        public LandsPageViewModel(
            INavigationService navigationService,
            ApiService apiService) : base(navigationService)
        {
            _apiService = apiService;      
            Title = "Lands";
            IsRunning = true;
            LoadLands();
        }

       public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        public ObservableCollection<Land> Lands
        {
            get => _lands;
            set => SetProperty(ref _lands, value);
        }


        private async void LoadLands()
        {
            IsRunning = true;
            IsEnabled = false;
   
            var response = await _apiService.GetListAsync<Response>(
               "https://restcountries.eu",
                "/rest",
                "/v2/all");

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }
            var list = (List<Land>)response.Result;
            Lands = new ObservableCollection<Land>(
                ToLandItemViewModel());
            IsRefreshing = false;

        }

        
        private IEnumerable<Land> ToLandItemViewModel()
        {
            return MainViewModel.GetInstance().LandsList.Select(l => new Land
            {
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders = l.Borders,
                CallingCodes = l.CallingCodes,
                Capital = l.Capital,
                Cioc = l.Cioc,
                Currencies = l.Currencies,
                Demonym = l.Demonym,
                Flag = l.Flag,
                Gini = l.Gini,             
                Latlng = l.Latlng,
                Name = l.Name,
                NativeName = l.NativeName,
                NumericCode = l.NumericCode,
                Population = l.Population,
                Region = l.Region,
                RegionalBlocs = l.RegionalBlocs,
                Subregion = l.Subregion,
                Timezones = l.Timezones,
                TopLevelDomain = l.TopLevelDomain,
                Translations = l.Translations,
            });        
        }
    }
}

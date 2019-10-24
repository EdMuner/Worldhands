using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Worldhands.Common.Models;
using Worldhands.Common.Services;

namespace Worldhands.Prism.ViewModels
{
    public class LandsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private ObservableCollection<LandItemViewModel> _lands;
        private bool _isEnabled;
        private string _filter;
        private List<LandResponse> _landList;
        private DelegateCommand _searchCommand;
        private bool _isRefreshing;


        public LandsPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "Lands";
            IsRefreshing = true;
            LoadLands();
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
        public ObservableCollection<LandItemViewModel> Lands
        {
            get => _lands;
            set => SetProperty(ref _lands, value);
        }
        public string Filter
        {
            get => _filter;
            set
            {
                SetProperty(ref _filter, value);
                SearchLand();
            }
        }

        public DelegateCommand SearchCommand => _searchCommand ?? (_searchCommand = new DelegateCommand(SearchLand));
        

        private async void LoadLands()
        {
            IsRefreshing = true;
            var url = App.Current.Resources["UrlAPI"].ToString();

            var connection = await _apiService.CheckConnectionAsync(url);

            if (!connection)
            {
                IsRefreshing = false;
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "Check the internet connection",
                    "Accept");
                return;
            }

            var response = await _apiService.GetListLandsAsync<LandResponse>(
                "http://restcountries.eu",
                "/rest",
                "/v2/all/");

            if (!response.IsSuccess)
            {
                IsRefreshing = false;
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            _landList = (List<LandResponse>)response.Result;
            Lands = new ObservableCollection<LandItemViewModel>(ToLandItemViewModel());
            IsRefreshing = false;
        }

        private void SearchLand()
        {
            if (string.IsNullOrEmpty(Filter))
            {
                Lands = new ObservableCollection<LandItemViewModel>(ToLandItemViewModel());

            }
            else
            {
                Lands = new ObservableCollection<LandItemViewModel>(
                    ToLandItemViewModel().Where(l => l.Name.ToLower().Contains(_filter.ToLower()) ||
                                         l.Capital.ToLower().Contains(_filter.ToLower())));
            }
        }

        private IEnumerable<LandItemViewModel> ToLandItemViewModel()
        {
            return _landList.Select(c => new LandItemViewModel(_navigationService)
            {
                Alpha2Code = c.Alpha2Code,
                Alpha3Code = c.Alpha3Code,
                AltSpellings = c.AltSpellings,
                Area = c.Area,
                Borders = c.Borders,
                CallingCodes = c.CallingCodes,
                Capital = c.Capital,
                Cioc = c.Cioc,
                Currencies = c.Currencies,
                Demonym = c.Demonym,
                Flag = c.Flag,
                Gini = c.Gini,
                Languages = c.Languages,
                Latlng = c.Latlng,
                Name = c.Name,
                NativeName = c.NativeName,
                NumericCode = c.NumericCode,
                Population = c.Population,
                Region = c.Region,
                RegionalBlocs = c.RegionalBlocs,
                Subregion = c.Subregion,
                Timezones = c.Timezones,
                TopLevelDomain = c.TopLevelDomain,
                Translations = c.Translations,
            });
        }
    }
}

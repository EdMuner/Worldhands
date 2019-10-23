using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Prism.Navigation;
using Worldhands.Common.Models;

namespace Worldhands.Prism.ViewModels
{
    public class LandViewModel : ViewModelBase
    {
        private ObservableCollection<Border> _borders;
        private ObservableCollection<Currency> _currencies;
        private ObservableCollection<Language> _languages;

     

        public LandViewModel(
            INavigationService navigationService,
            Land land) : base(navigationService)
        {
            Land = land;
            LoadBorders();
            Currencies = new ObservableCollection<Currency>(Land.Currencies);
            Languages = new ObservableCollection<Language>(Land.languages);

        }

        public Land Land
        {
            get;
            set;
        }
        public ObservableCollection<Border> Borders
        {
            get => _borders;
            set => SetProperty(ref _borders, value); 
        }
        public ObservableCollection<Currency> Currencies
        {
            get => _currencies;
            set => SetProperty(ref _currencies, value);
        }
        public ObservableCollection<Language> Languages
        {
            get => _languages;
            set => SetProperty(ref _languages, value);
        }

        private void LoadBorders()
        {
            
          
        }
    }
}


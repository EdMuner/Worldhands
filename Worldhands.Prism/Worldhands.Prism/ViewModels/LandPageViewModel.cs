using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Worldhands.Common.Models;
using Worldhands.Common.Services;

namespace Worldhands.Prism.ViewModels
{
    public class LandPageViewModel : ViewModelBase
    {
        private LandResponse _land;
      

        public LandPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {     
        }
        
        public LandResponse land
        {
            get => _land;
            set => SetProperty(ref _land, value);
        }


        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("land"))
            {
                land = parameters.GetValue<LandResponse>("Land");
                Title = "Information";
            }
        }
    }
}

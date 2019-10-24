using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Prism.Navigation;
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
            Title = "Details";
        }

        public LandResponse Land
        {
            get => _land;
            set => SetProperty(ref _land, value);
        }

        private static ISettings AppSettings => CrossSettings.Current;

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("land"))
            {
              
                Title = "Information";
            }
        }
    }
}

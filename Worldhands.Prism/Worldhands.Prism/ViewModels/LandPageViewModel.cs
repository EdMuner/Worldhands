using Prism.Navigation;
using Worldhands.Common.Models;

namespace Worldhands.Prism.ViewModels
{
    public class LandPageViewModel : ViewModelBase
    {

        private LandResponse _land;

        public LandPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
        }

        public LandResponse Country
        {
            get => _land;
            set => SetProperty(ref _land, value);
        }


        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("land"))
            {
                Country = parameters.GetValue<LandResponse>("land");
                Title = "Information";
            }
        }
    }
}

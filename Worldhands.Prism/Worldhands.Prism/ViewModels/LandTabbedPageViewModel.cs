using Prism.Navigation;

namespace Worldhands.Prism.ViewModels
{
    public class LandTabbedPageViewModel : ViewModelBase
    {
        public LandTabbedPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Land";
        }
    }
}

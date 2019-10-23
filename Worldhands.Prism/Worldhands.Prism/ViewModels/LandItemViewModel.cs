using GalaSoft.MvvmLight.Command;
using Prism.Navigation;
using System.Windows.Input;
using Worldhands.Common.Models;
using Worldhands.Prism.Views;
using Xamarin.Forms;

namespace Worldhands.Prism.ViewModels
{
    public class LandItemViewModel : ViewModelBase
    {
        public LandItemViewModel(
            INavigationService navigationService,
            Land land) : base(navigationService)
        {
        }

        public ICommand SelectLandCommand
        {
            get
            {
                return new RelayCommand(SelectLand);
            }
        }

        private async void SelectLand()
        {
         
            await Application.Current.MainPage.Navigation.PushAsync(new LandTabbedPage());
        }


    }
}

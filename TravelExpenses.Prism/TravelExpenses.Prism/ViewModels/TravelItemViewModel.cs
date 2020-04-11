using Prism.Commands;
using Prism.Navigation;
using TravelExpenses.Common.Models;
using TravelExpenses.Prism.Views;

namespace TravelExpenses.Prism.ViewModels
{
    public class TravelItemViewModel : TravelResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectTravel2Command;

        public TravelItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectTravel2Command => _selectTravel2Command ?? (_selectTravel2Command = new DelegateCommand(SelectTravel2Async));

        private async void SelectTravel2Async()
        {
            NavigationParameters parameters = new NavigationParameters
            {
                { "travel", this }
            };

            await _navigationService.NavigateAsync(nameof(MyTravelPage), parameters);
        }
    }
}

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelExpenses.Common.Models;
using TravelExpenses.Prism.Views;

namespace TravelExpenses.Prism.ViewModels
{
    public class MyTravelPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private TravelResponse _travel;
        private DelegateCommand _newExpenseCommand;

        public MyTravelPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Detalles del viaje";
        }

        public DelegateCommand NewExpenseCommand => _newExpenseCommand ?? (_newExpenseCommand = new DelegateCommand(GoToNewExpensePage));

        public TravelResponse Travel
        {
            get => _travel;
            set => SetProperty(ref _travel, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Travel = parameters.GetValue<TravelResponse>("travel");
        }

        public async void GoToNewExpensePage()
        {
            await _navigationService.NavigateAsync(nameof(NewExpensePage));
        }

    }

}
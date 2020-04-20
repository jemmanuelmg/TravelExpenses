using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace TravelExpenses.Prism.ViewModels
{
    public class HelpPageViewModel : ViewModelBase
    {
        public HelpPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Acerca de Travel Expenses";
        }
    }
}

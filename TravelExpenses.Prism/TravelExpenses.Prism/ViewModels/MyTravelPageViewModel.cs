using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelExpenses.Prism.ViewModels
{
    public class MyTravelPageViewModel : ViewModelBase
    {
        public MyTravelPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Detalles del Viaje";

        }
    }

}
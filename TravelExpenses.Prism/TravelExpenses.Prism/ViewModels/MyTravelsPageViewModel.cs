using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelExpenses.Prism.ViewModels
{
    
    public class MyTravelsPageViewModel : ViewModelBase
    {
        public MyTravelsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Ver Mis Viajes";
        }
    }
}

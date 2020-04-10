using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public class NewTravelPageViewModel : ViewModelBase
    {
        public NewTravelPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Agregar Nuevo Viaje";
        }
    }
}

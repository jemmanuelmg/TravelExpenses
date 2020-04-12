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
        private readonly INavigationService _navigationService;
        private DelegateCommand _saveTravel;

        public NewTravelPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Agregar Nuevo Viaje";
        }

        public DelegateCommand SaveTravel => _saveTravel ?? (_saveTravel = new DelegateCommand(SaveNewTravel));

        public void SaveNewTravel()
        {
            int a = 1;
            int b = 2;
        }
    }
}

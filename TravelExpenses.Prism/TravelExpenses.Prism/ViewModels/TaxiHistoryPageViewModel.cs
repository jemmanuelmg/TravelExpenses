﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelExpenses.Prism.ViewModels
{
    public class TaxiHistoryPageViewModel : ViewModelBase
    {
        public TaxiHistoryPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Taxi History";
        }
    }

}

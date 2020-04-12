using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelExpenses.Common.Helpers;
using TravelExpenses.Common.Models;
using TravelExpenses.Common.Services;
using TravelExpenses.Prism.Helpers;


namespace TravelExpenses.Prism.ViewModels
{

    public class MyTravelsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private bool _isRunning;    
        private List<TravelItemViewModel> _travels;
        private DelegateCommand _refreshCommand;

        public MyTravelsPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "Ver Mis Viajes";
            LoadTravelsAsync();
        }

        
        public DelegateCommand RefreshCommand => _refreshCommand ?? (_refreshCommand = new DelegateCommand(LoadTravelsAsync));

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<TravelItemViewModel> Travels
        {
            get => _travels;
            set => SetProperty(ref _travels, value);
        }
        

       public bool IsRunning
       {
           get => _isRunning;
           set => SetProperty(ref _isRunning, value);
       }
               
        private async void LoadTravelsAsync()
        {
            IsRunning = true;

            string url = App.Current.Resources["UrlAPI"].ToString();
            bool connection = await _apiService.CheckConnectionAsync(url);
            if (!connection)
            {
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert("Error", "No hay conexión a Internet. Porfavor verifíquela", "Aceptar");
                return;
            }

            TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            UserResponse user = JsonConvert.DeserializeObject<UserResponse>(Settings.User);
            MyTravelsRequest request = new MyTravelsRequest
            {
                UserId = user.Id
            };

            Response response = await _apiService.GetMyTravels(url, "api", "/Travels/GetMyTravels", "bearer", token.Token, request);

            IsRunning = false;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            List<TravelResponse> travels = (List<TravelResponse>)response.Result;
            Travels = travels.Select(t => new TravelItemViewModel(_navigationService)
            {
                Id = t.Id,
                StartDate = t.StartDate,
                EndDate = t.EndDate,
                City = t.City,
                Expenses = t.Expenses,
                User = t.User
            }).ToList();

            foreach(TravelItemViewModel element in Travels)
            {
                TravelItemViewModel lala = element;
                string city = element.City;
                DateTime startDate = element.StartDate;
                int a = 1;

            }

        }
        

    }
}

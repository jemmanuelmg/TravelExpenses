using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using TravelExpenses.Common.Helpers;
using TravelExpenses.Common.Models;
using TravelExpenses.Common.Services;
using TravelExpenses.Prism.Views;

namespace TravelExpenses.Prism.ViewModels
{
    public class NewTravelPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private bool _isRunning;
        private bool _isEnabled;
        private TravelRequest _travel;
        private DelegateCommand _saveTravel;


        public NewTravelPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            _travel = new TravelRequest();
            Title = "Agregar Nuevo Viaje";
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
        }

        public DelegateCommand SaveTravel => _saveTravel ?? (_saveTravel = new DelegateCommand(SaveNewTravel));

        public string City { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public TravelRequest Travel
        {
            get => _travel;
            set => SetProperty(ref _travel, value);
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }



        private async void SaveNewTravel()
        {
            bool isValid = await ValidateDataAsync();
            if (!isValid)
            {
                return;
            }

            IsRunning = true;
            IsEnabled = false;
            string url = App.Current.Resources["UrlAPI"].ToString();
            bool connection = await _apiService.CheckConnectionAsync(url);
            if (!connection)
            {
                IsRunning = false;
                IsEnabled = true;
                await App.Current.MainPage.DisplayAlert("Error", "No hay conexión a Internet", "Aceptar");
                return;
            }

            UserResponse user = JsonConvert.DeserializeObject<UserResponse>(Settings.User);
            TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);

            var travelRequest = new TravelRequest
            {
                UserId = Guid.Parse(user.Id),
                City = City,
                StartDate = StartDate,
                EndDate = EndDate
            };

            var response = await _apiService.AddNewTravel(url, "/api", "/Travels", "bearer", token.Token, travelRequest);
            IsRunning = false;
            IsEnabled = true;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            await App.Current.MainPage.DisplayAlert("Ok", "Nuevo viaje agregado correctamente", "Aceptar");
            await _navigationService.NavigateAsync(nameof(MyTravelsPage));


        }

        private async Task<bool> ValidateDataAsync()
        {
            if (string.IsNullOrEmpty(City))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Porfavor ingrese una ciudad de destino", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(StartDate.ToString()))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Porfavor ingrese la fecha de partida", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(EndDate.ToString()))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Porfavor ingrese la fecha de llegada", "Aceptar");
                return false;
            }

            return true;
        }
    }
}

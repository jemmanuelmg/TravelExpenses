using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TravelExpenses.Common.Helpers;
using TravelExpenses.Common.Models;
using TravelExpenses.Common.Services;
using TravelExpenses.Prism.Helpers;
using Xamarin.Forms;

namespace TravelExpenses.Prism.ViewModels
{
    public class RegisterPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IRegexHelper _regexHelper;
        private readonly IApiService _apiService;
        private ImageSource _image;
        private UserRequest _user;
        private Role _role;
        private ObservableCollection<Role> _roles;
        private bool _isRunning;
        private bool _isEnabled;
        private DelegateCommand _registerCommand;

        public RegisterPageViewModel(INavigationService navigationService, IRegexHelper regexHelper, IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _regexHelper = regexHelper;
            _apiService = apiService;
            Title = "Registrarse";
            Image = App.Current.Resources["UrlNoImage"].ToString();
            IsEnabled = true;
            User = new UserRequest();
            Roles = new ObservableCollection<Role>(CombosHelper.GetRoles());
        }

        public DelegateCommand RegisterCommand => _registerCommand ?? (_registerCommand = new DelegateCommand(RegisterAsync));

        public ImageSource Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        public UserRequest User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public Role Role
        {
            get => _role;
            set => SetProperty(ref _role, value);
        }

        public ObservableCollection<Role> Roles
        {
            get => _roles;
            set => SetProperty(ref _roles, value);
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

        private async void RegisterAsync()
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

            User.UserTypeId = Role.Id;
            User.CultureInfo = "es";
            Response response = await _apiService.RegisterUserAsync(url, "/api", "/Account", User);
            IsRunning = false;
            IsEnabled = true;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            await App.Current.MainPage.DisplayAlert("Completado", response.Message, "Aceptar");
            await _navigationService.GoBackAsync();


        }

        private async Task<bool> ValidateDataAsync()
        {
            if (string.IsNullOrEmpty(User.Document))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Porfavor ingrese un No. de documento válido", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(User.FirstName))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Porfavor ingrese nombre(s) válido", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(User.LastName))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Porfavor ingrese apellido(s) válido", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(User.Email) || !_regexHelper.IsValidEmail(User.Email))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Porfavor ingrese un email válido", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(User.Phone))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Porfavor ingrese un teléfono válido", "Aceptar");
                return false;
            }

            if (Role == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Porfavor ingrese un tipo de usuario válido", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(User.Password) || User.Password?.Length < 6)
            {
                await App.Current.MainPage.DisplayAlert("Error", "La contraseña debe tener mínimo 6 caractéres", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(User.PasswordConfirm))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Porfavor vuelva a introducir su contraseña", "Aceptar");
                return false;
            }

            if (User.Password != User.PasswordConfirm)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Las contraseñas no coinciden, porfavor cuelva a intentarlo", "Aceptar");
                return false;
            }

            return true;
        }
    }
}


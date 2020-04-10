using Newtonsoft.Json;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TravelExpenses.Common.Helpers;
using TravelExpenses.Common.Models;
using TravelExpenses.Common.Services;
using TravelExpenses.Prism.Helpers;

namespace TravelExpenses.Prism.ViewModels
{
    public class TravelMasterDetailPageViewModel : ViewModelBase
    {
        private readonly IApiService _apiService;
        private static TravelMasterDetailPageViewModel _instance;
        private readonly INavigationService _navigationService;
        private UserResponse _user;

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        public TravelMasterDetailPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _instance = this;
            _apiService = apiService;
            _navigationService = navigationService;
            LoadUser();
            LoadMenus();
        }

        public static TravelMasterDetailPageViewModel GetInstance()
        {
            return _instance;
        }


        public UserResponse User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        private void LoadUser()
        {
            if (Settings.IsLogin)
            {
                User = JsonConvert.DeserializeObject<UserResponse>(Settings.User);
            }
        }

        private void LoadMenus()
        {
            List<Menu> menus = new List<Menu>();

            menus.Add(new Menu
            {
                Icon = "ic_home",
                PageName = "HomePage",
                Title = "Inicio"
            });

            menus.Add(new Menu
            {
                Icon = "ic_exit_to_app",
                PageName = "LoginPage",
                Title = Settings.IsLogin ? "Cerrar Sesión" : "Iniciar Sesión"
            });

            if (Settings.IsLogin) { 

                menus.Add(new Menu
                {
                    Icon = "ic_account_circle",
                    PageName = "ModifyUserPage",
                    Title = "Modificar Usuario"
                });

                menus.Add(new Menu
                {
                    Icon = "ic_map",
                    PageName = "MyTravelsPage",
                    Title = "Ver mis viajes"
                });

                menus.Add(new Menu
                {
                    Icon = "ic_border_color",
                    PageName = "NewTravelPage",
                    Title = "Agregar Nuevo Viaje"
                });

            }


            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title
                }).ToList());
        }

        public async void ReloadUser()
        {
            string url = App.Current.Resources["UrlAPI"].ToString();
            bool connection = await _apiService.CheckConnectionAsync(url);
            if (!connection)
            {
                return;
            }

            UserResponse user = JsonConvert.DeserializeObject<UserResponse>(Settings.User);
            TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            EmailRequest emailRequest = new EmailRequest
            {
                CultureInfo = "es",
                Email = user.Email
            };

            Response response = await _apiService.GetUserByEmail(url, "api", "/Account/GetUserByEmail", "bearer", token.Token, emailRequest);
            UserResponse userResponse = (UserResponse)response.Result;
            Settings.User = JsonConvert.SerializeObject(userResponse);
            LoadUser();
        }

        private async void ModifyUserAsync()
        {
            await _navigationService.NavigateAsync("/TaxiMasterDetailPage/NavigationPage/ModifyUserPage");
        }

    }
}

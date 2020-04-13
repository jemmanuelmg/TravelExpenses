using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
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
    public class NewExpensePageViewModel : ViewModelBase
    {

        private bool _isRunning;
        private bool _isEnabled;
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private readonly IFilesHelper _filesHelper;
        private MediaFile _file;
        private ImageSource _image;
        private ExpenseCategory _category;
        private TravelResponse _travel;
        private ObservableCollection<ExpenseCategory> _categories;
        private DelegateCommand _saveExpense;
        private DelegateCommand _changeImageCommand;

        public NewExpensePageViewModel(INavigationService navigationService, IApiService apiService, IFilesHelper filesHelper) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            _filesHelper = filesHelper;
            _travel = new TravelResponse();
            Title = "Agregar Nuevo Gasto";
            IsEnabled = true;
            IsRunning = false;
            Categories = new ObservableCollection<ExpenseCategory>(CombosHelper.GetExpenseCategories());
            Image = App.Current.Resources["UrlNoImage"].ToString();

        }

        public DelegateCommand SaveExpense => _saveExpense ?? (_saveExpense = new DelegateCommand(SaveNewExpense));

        public DelegateCommand ChangeImageCommand => _changeImageCommand ?? (_changeImageCommand = new DelegateCommand(ChangeImageAsync));

        public int Value { get; set; }

        public string Comment { get; set; }

        public TravelResponse Travel
        {
            get => _travel;
            set => SetProperty(ref _travel, value);
        }

        public ExpenseCategory Category
        {
            get => _category;
            set => SetProperty(ref _category, value);
        }

        public ObservableCollection<ExpenseCategory> Categories
        {
            get => _categories;
            set => SetProperty(ref _categories, value);
        }

        public ImageSource Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
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

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Travel = parameters.GetValue<TravelResponse>("travel");
        }

        private async void SaveNewExpense()
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

            byte[] imageArray = null;
            if (_file != null)
            {
                imageArray = _filesHelper.ReadFully(_file.GetStream());
            }

            var expenseRequest = new ExpenseRequest
            {
                Value = Value,
                Comment = Comment,
                ExpenseTypeId = Category.Id,
                PictureArray = imageArray,
                TravelId = Travel.Id
            };

            var response = await _apiService.AddNewTravel(url, "/api", "/Expenses", "bearer", token.Token, expenseRequest);
            IsRunning = false;
            IsEnabled = true;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            await App.Current.MainPage.DisplayAlert("Ok", "Nuevo gasto agregado correctamente", "Aceptar");
            await _navigationService.GoBackAsync();
            //await _navigationService.NavigateAsync("/TravelMasterDetailPage/NavigationPage/HomePage");

        }

        private async void ChangeImageAsync()
        {
            await CrossMedia.Current.Initialize();

            string source = await Application.Current.MainPage.DisplayActionSheet(
                "Obtener imagen de:",
                "Cancelar",
                null,
                "Galeria",
                "Camara");

            if (source == "Cancelar")
            {
                _file = null;
                return;
            }

            if (source == "Camara")
            {
                _file = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        Directory = "Sample",
                        Name = "test.jpg",
                        PhotoSize = PhotoSize.Small,
                    }
                );
            }
            else
            {
                _file = await CrossMedia.Current.PickPhotoAsync();
            }

            if (_file != null)
            {
                Image = ImageSource.FromStream(() =>
                {
                    System.IO.Stream stream = _file.GetStream();
                    return stream;
                });
            }
        }

        private async Task<bool> ValidateDataAsync()
        {
            if (string.IsNullOrEmpty(Value.ToString()))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Porfavor el valor del gasto", "Aceptar");
                return false;
            }

            if (Category == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Porfavor elija una categoría para el gasto", "Aceptar");
                return false;
            }

            return true;
        }

    }
}


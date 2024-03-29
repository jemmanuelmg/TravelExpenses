﻿using Prism;
using Prism.Ioc;
using Syncfusion.Licensing;
using TravelExpenses.Common.Helpers;
using TravelExpenses.Common.Services;
using TravelExpenses.Prism.ViewModels;
using TravelExpenses.Prism.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TravelExpenses.Prism
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         * 
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            //Version 17 Synfusion
            //SyncfusionLicenseProvider.RegisterLicense("MjI5MTc5QDMxMzcyZTM0MmUzME5LQ2NlMGk3ckNiMGh4enZEaHlpMnZ4YmhwWmthUnZxNzJlTjFrbjlPV2s9");

            //Version 18 Synfusion
            SyncfusionLicenseProvider.RegisterLicense("MjQzMjMxQDMxMzgyZTMxMmUzMGF1bmlMLyt2NE1tK0J1OFNkYjJDZkl2Z1BLYSs0VXBqWTY4ZUMxR3BYc289");

            InitializeComponent();
            await NavigationService.NavigateAsync("/TravelMasterDetailPage/NavigationPage/HomePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.Register<IRegexHelper, RegexHelper>();
            containerRegistry.Register<IFilesHelper, FilesHelper>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<TravelMasterDetailPage, TravelMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<GroupPage, GroupPageViewModel>();
            containerRegistry.RegisterForNavigation<TaxiHistoryPage, TaxiHistoryPageViewModel>();
            containerRegistry.RegisterForNavigation<ModifyUserPage, ModifyUserPageViewModel>();
            containerRegistry.RegisterForNavigation<ReportPage, ReportPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
            containerRegistry.RegisterForNavigation<RememberPasswordPage, RememberPasswordPageViewModel>();
            containerRegistry.RegisterForNavigation<MyTravelsPage, MyTravelsPageViewModel>();
            containerRegistry.RegisterForNavigation<NewTravelPage, NewTravelPageViewModel>();
            containerRegistry.RegisterForNavigation<ChangePasswordPage, ChangePasswordPageViewModel>();
            containerRegistry.RegisterForNavigation<MyTravelPage, MyTravelPageViewModel>();
            containerRegistry.RegisterForNavigation<NewExpensePage, NewExpensePageViewModel>();
            containerRegistry.RegisterForNavigation<HelpPage, HelpPageViewModel>();
        }
    }
}

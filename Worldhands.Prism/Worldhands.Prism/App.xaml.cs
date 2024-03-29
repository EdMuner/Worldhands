﻿using Prism;
using Prism.Ioc;
using Worldhands.Common.Services;
using Worldhands.Prism.ViewModels;
using Worldhands.Prism.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Worldhands.Prism
{
    public partial class App
    {

        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<LandsPage, LandsPageViewModel>();
            containerRegistry.RegisterForNavigation<LandTabbedPage, LandTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<BorderPage, BorderPageViewModel>();
            containerRegistry.RegisterForNavigation<TranslationPage, TranslationPageViewModel>();
            containerRegistry.RegisterForNavigation<LanguagePage, LanguagePageViewModel>();
        }
    }
}

﻿using System.Collections.Generic;

using MasterDetail.Helpers;
using MasterDetail.Services;
using MasterDetail.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MasterDetail
{
	public partial class App : Application
	{
        //MUST use HTTPS, neglecting to do so will result in runtime errors on iOS
		public static bool AzureNeedsSetup => AzureMobileAppUrl == "https://CONFIGURE-THIS-URL.azurewebsites.net";
		public static string AzureMobileAppUrl = "https://CONFIGURE-THIS-URL.azurewebsites.net";
        public static IDictionary<string, string> LoginParameters => null;

        public App()
		{
			InitializeComponent();

			if (AzureNeedsSetup)
				DependencyService.Register<MockDataStore>();
			else
				DependencyService.Register<AzureDataStore>();

			SetMainPage();
		}

		public static void SetMainPage()
		{
            if (!AzureNeedsSetup && !Settings.IsLoggedIn)
            {
                Current.MainPage = new NavigationPage(new LoginPage())
                {
                    BarBackgroundColor = (Color)Current.Resources["Primary"],
                    BarTextColor = Color.White
                };
            }
            else
            {
                GoToMainPage();
            }
		}

        public static void GoToMainPage()
        {
            Current.MainPage = new TabbedPage
			{
				Children =
				{
					new NavigationPage(new ItemsPage())
					{
						Title = "Browse",
						Icon = "tab_feed.png"
					},
					new NavigationPage(new AboutPage())
					{
						Title = "About",
						Icon = "tab_about.png"
					},
				}
			};
        }
	}
}

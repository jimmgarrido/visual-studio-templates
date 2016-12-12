using System.Collections.Generic;

using MasterDetail.Helpers;
using MasterDetail.Models;
using MasterDetail.Services;
using MasterDetail.Views;

using Xamarin.Forms;

namespace MasterDetail
{
	public partial class App : Application
	{
        public App()
		{
			InitializeComponent();

			SetMainPage();
		}

		public static void SetMainPage()
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

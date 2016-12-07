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
                        Title = "Browse"
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About"
                    },
                }
            };
        }
	}
}

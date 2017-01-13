using System.Collections.Generic;
using MasterDetail.Helpers;
using MasterDetail.Interfaces;
using MasterDetail.Services;
using MasterDetail.Model;
using System;
using System.Threading.Tasks;

namespace MasterDetail
{
    public partial class App 
    {
        //MUST use HTTPS, neglecting to do so will result in runtime errors on iOS
        public static bool AzureNeedsSetup => AzureMobileAppUrl == "https://CONFIGURE-THIS-URL.azurewebsites.net";
		public static string AzureMobileAppUrl = "https://CONFIGURE-THIS-URL.azurewebsites.net";

        public App()
        {

        }

        public static void Initialize()
        {
            if (AzureNeedsSetup)
                ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();
            else
                ServiceLocator.Instance.Register<IDataStore<Item>, AzureDataStore>();

            var store = ServiceLocator.Instance.Get<IDataStore<Item>>();
            store.InitializeAsync();
        }

        public static IDictionary<string, string> LoginParameters => null;
    }
}
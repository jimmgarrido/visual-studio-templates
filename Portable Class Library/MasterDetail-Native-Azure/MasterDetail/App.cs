using System.Collections.Generic;
using MasterDetail.Helpers;
using MasterDetail.Interfaces;
using MasterDetail.Services;
using MasterDetail.Model;
using System;
namespace MasterDetail
{
    public partial class App 
    {
        //MUST use HTTPS, neglecting to do so will result in runtime errors on iOS
        public static bool AzureNeedsSetup => AzureMobileAppUrl == "https://CONFIGURE-THIS-URL.azurewebsites.net";
		public static string AzureMobileAppUrl = "https://CONFIGURE-THIS-URL.azurewebsites.net";

        public App()
        {
            if (AzureNeedsSetup)
                ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();
            else
                ServiceLocator.Instance.Register<IDataStore<Item>, AzureDataStore>();
            
            ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();
        }

        public static void Initialize()
        {
        }

        public static IDictionary<string, string> LoginParameters => null;
    }
}
using System.Collections.Generic;
#if __ANDROID__
using MasterDetail.Droid.Helpers;
#elif __IOS__
using MasterDetail.iOS.Helpers;
#elif WINDOWS_UWP
using MasterDetail.UWP.Helpers;
#endif
using MasterDetail.Helpers;
using MasterDetail.Interfaces;
using MasterDetail.Services;
using Microsoft.Identity.Client;
using MasterDetail.Model;

#if AZURE

#else
//using MasterDetail.Services.Standard;
#endif
using System;
namespace MasterDetail
{
    public partial class App 
    {
        //MUST use HTTPS, neglecting to do so will result in runtime errors on iOS
        public static bool AzureNeedsSetup => AzureMobileAppUrl == "CobeyConnectedTest20161212.azurewebsites.net";
        public static string AzureMobileAppUrl = "CobeyConnectedTest20161212.azurewebsites.net";

        public App()
        {

            if (!AzureNeedsSetup)
                ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();
            else
                ServiceLocator.Instance.Register<IDataStore<Item>, AzureDataStore>();
#if __IOS__
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
            SQLitePCL.CurrentPlatform.Init();
#elif __ANDROID__
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
#endif
            ServiceLocator.Instance.Register<IMessageDialog, MessageDialog>();
            ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();
        }

        public static void Initialize()
        {




        }

        public static IDictionary<string, string> LoginParameters => null;
    }
}
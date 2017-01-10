using System.Threading.Tasks;
using System.Windows.Input;

using MasterDetail.Helpers;
using MasterDetail.Services;
using MasterDetail.Model;

#if __IOS__
using MasterDetail.iOS.Authentication;
#elif __ANDROID__
using MasterDetail.Droid.Authentication;
#elif WINDOWS_UWP
using MasterDetail.UWP.Authentication;
#endif

namespace MasterDetail.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {

        public LoginViewModel()
        {

        }

        string message = string.Empty;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged(); }
        }

        public ICommand NotNowCommand { get; }
        public ICommand SignInCommand { get; }

        public async Task SignIn()
        {
            try
            {
                IsBusy = true;
                Message = "Signing In...";

                // Log the user in
                await TryLoginAsync();
            }
            finally
            {
                Message = string.Empty;
                IsBusy = false;

            }
        }


        public static async Task<bool> TryLoginAsync()
        {

			ServiceLocator.Instance.Register<IDataStore<Item>, AzureDataStore>();
			var authentication = new SocialAuthenticator();
            authentication.ClearCookies();

            var dataStore = ServiceLocator.Instance.Get<IDataStore<Item>>() as AzureDataStore;
            await dataStore.InitializeAsync();
            var user = await authentication.LoginAsync(dataStore.MobileService, dataStore.AuthProvider, App.LoginParameters);
            if (user == null)
            {
                

            }

            Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
            Settings.UserId = user?.UserId ?? string.Empty;
            return true;
        }
    }
}
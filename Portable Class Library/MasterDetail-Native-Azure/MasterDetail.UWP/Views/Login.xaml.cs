#define AZURE


using MasterDetail.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MasterDetail.UWP.Views
{
    public sealed partial class Login : Page
    {
       // Button signInButton, notNowButton;
       // LinearLayout signingInPanel;
        public Login()
        {
            this.InitializeComponent();
            MasterDetail.App.Initialize();
            DataContext = new LoginViewModel();

        }

        private void ImageBrush_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void btnNotNow_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPivot), null);
        }
    }
}

using System.Windows.Input;

namespace MasterDetail.ViewModel
{
	public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

			//OpenWebCommand = new Command(() => CrossShare.Current.OpenBrowser("https://xamarin.com/platform"));
        }


        /// <summary>
        /// Command to open browser to xamarin.com
        /// </summary>
        public ICommand OpenWebCommand { get; }
    }
}

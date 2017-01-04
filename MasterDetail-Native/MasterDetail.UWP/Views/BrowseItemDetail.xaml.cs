using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MasterDetail.Model;
using MasterDetail.ViewModel;

namespace MasterDetail.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BrowseItemDetail : Page
    {

        public ItemDetailViewModel ViewModel { get; set; }
        int quantityCount = 0;
        public BrowseItemDetail()
        {
            this.InitializeComponent();

            ViewModel = new ItemDetailViewModel();
            DataContext = new ItemDetailViewModel();
        }

        public void Show_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("yay");
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.Item = (Item)e.Parameter;

            txtText.Text = ViewModel.Item.Text;
            txtDesc.Text = ViewModel.Item.Description;
        }
    }

}

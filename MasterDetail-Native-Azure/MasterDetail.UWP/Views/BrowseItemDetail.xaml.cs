using MasterDetail.Model;
using MasterDetail.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MasterDetail.UWP.Views
{
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.Item = (Item)e.Parameter;

            txtText.Text = ViewModel.Item.Text;
            txtDesc.Text = ViewModel.Item.Description;
        }
    }
}
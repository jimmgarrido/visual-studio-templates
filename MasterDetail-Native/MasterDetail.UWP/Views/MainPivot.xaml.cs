using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MasterDetail.Model;

using MasterDetail.ViewModel;
using System.Collections.Specialized;
using Windows.UI.Core;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MasterDetail.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
   
    public sealed partial class MainPivot : Page
    {
        private ItemsViewModel browseViewModel;
        Task loadItems;

        public MainPivot()
        {
            InitializeComponent();

            browseViewModel = (ItemsViewModel)this.DataContext;
            loadItems = browseViewModel.ExecuteLoadItemsCommand();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            gvItems.ItemsSource = browseViewModel.Items;
            gvItems.ItemClick += GvItems_ItemClick;

            if (browseViewModel.Items.Count == 0)
                loadItems.Wait();
        }


        public void Show_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddItems));
        }

        private void GvItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as Item;
            if (item == null)
            {
                return;
            }
            // this.Frame.Navigate(typeof(BrowseItemDetail((item)));
            var db = new ItemDetailViewModel(item);
            this.Frame.Navigate(typeof(BrowseItemDetail), item);
            gvItems.SelectedItem = null;
        }

    }
}

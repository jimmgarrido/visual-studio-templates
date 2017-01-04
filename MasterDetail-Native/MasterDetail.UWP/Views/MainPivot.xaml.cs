﻿using MasterDetail.Model;
using MasterDetail.ViewModel;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MasterDetail.UWP.Views
{
    public sealed partial class MainPivot : Page
    {
        public ItemsViewModel BrowseViewModel { get; private set; }
        public AboutViewModel AboutViewModel { get; private set; }

        Task loadItems;

        public MainPivot()
        {
            InitializeComponent();

            BrowseViewModel = new ItemsViewModel();
            AboutViewModel = new AboutViewModel();

            loadItems = BrowseViewModel.ExecuteLoadItemsCommand();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (BrowseViewModel.Items.Count == 0)
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

            var db = new ItemDetailViewModel(item);
            this.Frame.Navigate(typeof(BrowseItemDetail), item);
        }

        private void PivotItemChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((Pivot)sender).SelectedIndex)
            {
                case 0:
                    Toolbar.Visibility = Visibility.Visible;
                    break;
                case 1:
                    Toolbar.Visibility = Visibility.Collapsed;
                    break;
            }
        }
    }
}

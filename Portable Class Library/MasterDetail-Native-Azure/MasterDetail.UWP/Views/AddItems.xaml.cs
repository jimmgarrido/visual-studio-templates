﻿using MasterDetail.Helpers;
using MasterDetail.Model;
using MasterDetail.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MasterDetail.UWP.Views
{
    public sealed partial class AddItems : Page
    {
        ItemsViewModel ViewModel { get; set; }

        public AddItems()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ViewModel = (ItemsViewModel)e.Parameter;
        }

        private async void SaveItem_Click(object sender, RoutedEventArgs e)
        {
            var _item = new Item();
            _item.Text = txtText.Text;
            _item.Description = txtDesc.Text;
            await ViewModel.AddItem(_item);

            this.Frame.GoBack();
        }
    }
}
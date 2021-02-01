using System;
using System.Collections.Generic;

using Xamarin.Forms;

using Mine.Models;
using Mine.ViewModels;

namespace Mine.Views.Items
{
    public partial class ItemDeletePage : ContentPage
    {
        ItemReadViewModel viewModel;

        public ItemDeletePage(ItemReadViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDeletePage()
        {
            InitializeComponent();

            var item = new ItemModel
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemReadViewModel(item);
            BindingContext = viewModel;
        }

        public async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DeleteItem", viewModel.Item);
            await Navigation.PopModalAsync();
        }
    }
}

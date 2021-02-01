using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Mine.Models;
using Mine.ViewModels;

namespace Mine.Views.Items
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemReadPage : ContentPage
    {
        ItemReadViewModel viewModel;

        public ItemReadPage(ItemReadViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }


        public ItemReadPage()
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

        /// <summary>
        /// Open the delete page for this item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ItemDeletePage(viewModel)));
            await Navigation.PopAsync();
        }
    }
}
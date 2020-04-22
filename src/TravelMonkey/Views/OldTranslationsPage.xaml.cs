using System;
using TravelMonkey.Models;
using TravelMonkey.ViewModels;
using Xamarin.Forms;

namespace TravelMonkey.Views
{
    public partial class OldTranslationsPage : ContentPage
    {
        private readonly OldTranslationsViewModel viewModel =
            new OldTranslationsViewModel();

        public OldTranslationsPage()
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.Refresh();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            viewModel.Goto(e.Item as OldSearchs);
        }
    }
}
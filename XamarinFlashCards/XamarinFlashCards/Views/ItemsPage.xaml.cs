using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinFlashCards
{
    public partial class ItemsPage : ContentPage
    {
        ChaptersViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ChaptersViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Chapter;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewChapterPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Chapters.Count == 0)
                viewModel.LoadChaptersCommand.Execute(null);
        }
    }
}

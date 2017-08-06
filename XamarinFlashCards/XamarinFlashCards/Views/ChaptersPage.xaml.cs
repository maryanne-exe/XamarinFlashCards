using System;

using Xamarin.Forms;

namespace XamarinFlashCards
{
    public partial class ChaptersPage : ContentPage
    {
        ChaptersViewModel viewModel;

        public ChaptersPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ChaptersViewModel();
        }

        async void OnChapterSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Chapter;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ChaptersListView.SelectedItem = null;
        }

        async void AddChapter_Clicked(object sender, EventArgs e)
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

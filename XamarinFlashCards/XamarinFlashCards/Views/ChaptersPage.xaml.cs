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
            var chapter = args.SelectedItem as Chapter;
            if (chapter == null)
                return;

            await Navigation.PushAsync(new ChapterCardsPage(new ChapterCardsViewModel(chapter)));

            // Manually deselect item
            ChaptersListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Chapters.Count == 0)
                viewModel.LoadChaptersCommand.Execute(null);
        }
    }
}

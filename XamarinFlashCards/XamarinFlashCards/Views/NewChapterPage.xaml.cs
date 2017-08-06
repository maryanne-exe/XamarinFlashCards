using System;

using Xamarin.Forms;

namespace XamarinFlashCards
{
    public partial class NewChapterPage : ContentPage
    {
        public Chapter Item { get; set; }

        public NewChapterPage()
        {
            InitializeComponent();

            Item = new Chapter {
                Title = "Chapter name",
                Description = "This is a nice description"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddChapter", Item);
            await Navigation.PopToRootAsync();
        }
    }
}

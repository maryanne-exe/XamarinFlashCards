using Xamarin.Forms;

namespace XamarinFlashCards
{
    public partial class ChapterCardsPage : CarouselPage
    {
        public ChapterCardsPage(ChapterCardsViewModel model)
        {
            InitializeComponent ();
            BindingContext = model;

            ItemsSource = model.Chapter.Questions;
        }
    }
}

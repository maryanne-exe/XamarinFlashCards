namespace XamarinFlashCards
{
    public class ChapterCardsViewModel : BaseViewModel
    {
        public Chapter Chapter { get; set; }

        public ChapterCardsViewModel (Chapter chapter)
        {
            Chapter = chapter;
            Title = "Cards";
        }
    }
}


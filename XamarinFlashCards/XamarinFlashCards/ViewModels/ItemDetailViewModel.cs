namespace XamarinFlashCards
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Chapter Chapter { get; set; }
        public ItemDetailViewModel (Chapter chapter = null)
        {
            Title = chapter.Title;
            Chapter = chapter;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}

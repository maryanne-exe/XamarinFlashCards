using Xamarin.Forms;

namespace XamarinFlashCards
{
    public partial class ChapterDetailPage : ContentPage
    {
        ChapterDetailViewModel viewModel;

        public ChapterDetailPage(ChapterDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}

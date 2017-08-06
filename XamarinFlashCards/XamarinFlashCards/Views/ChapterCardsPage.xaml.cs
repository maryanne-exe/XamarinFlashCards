using System;
using Xamarin.Forms;

namespace XamarinFlashCards
{
    public enum PageScrollDirection
    {
        Left,
        Right
    }

    public partial class ChapterCardsPage : CarouselPage
    {
        public ChapterCardsPage(ChapterCardsViewModel model)
        {
            InitializeComponent ();
            BindingContext = model;

            ItemsSource = model.Chapter.Questions;
        }

        void OnAnswerSelected(object sender, SelectedItemChangedEventArgs args)
		{
            var answer = args.SelectedItem as Answer;
			
            if (answer == null)
				return;

            Console.WriteLine(answer.IsCorrect ? "Correct!" : "Incorrrect!");

            ScrollCarouselPage(PageScrollDirection.Right);
		}

        void ScrollCarouselPage(PageScrollDirection direction)
		{
			var pageCount = Children.Count;
			if (pageCount < 2)
				return;

			var index = Children.IndexOf(CurrentPage);

            if (direction == PageScrollDirection.Right)
                index++;
            else
                index--;

            if (index >= pageCount)
                index = pageCount - 1;
            else if (index < 0)
                index = 0;

            Device.BeginInvokeOnMainThread(() => {
                CurrentPage = Children[index];
            });
		}
    }
}

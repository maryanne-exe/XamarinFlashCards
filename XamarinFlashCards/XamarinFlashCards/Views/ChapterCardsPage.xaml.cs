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
        // Properties
        Label CurrentResultLabel => CurrentPage.FindByName<Label>("resultLabel");
        StackLayout CurrentQuestionView => CurrentPage.FindByName<StackLayout>("questionView");
		StackLayout CurrentResultView => CurrentPage.FindByName<StackLayout>("resultView");
        ListView CurrentAnswersListView => CurrentPage.FindByName<ListView>("answersListView");

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
            
            DisplayAnswerResult(answer.IsCorrect);
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

            if (index >= pageCount || index < 0)
                index = 0;

            Device.BeginInvokeOnMainThread(() => {
                CurrentPage = Children[index];
            });
		}

		void DisplayAnswerResult(bool correct)
		{
            if (correct == true) {
                CurrentResultLabel.Text = "Correct!";
                CurrentResultLabel.TextColor = Color.FromHex("#fff");
                CurrentResultLabel.BackgroundColor = Color.FromHex("91C46C");             
            }
            else {
                CurrentResultLabel.Text = "Wrong :(";
				CurrentResultLabel.TextColor = Color.FromHex("#fff");
				CurrentResultLabel.BackgroundColor = Color.FromHex("EA6045");
			}

            CurrentQuestionView.IsVisible = false;
            CurrentResultView.IsVisible = true;
		}

        void OnNextButtonClicked(object sender, EventArgs args)
        {
			CurrentQuestionView.IsVisible = true;
            CurrentResultView.IsVisible = false;
            CurrentAnswersListView.SelectedItem = null;

            ScrollCarouselPage(PageScrollDirection.Right);
        }
    }
}

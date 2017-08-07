namespace XamarinFlashCards
{
    public class Answer : ObservableObject
    {
        string answerText = string.Empty;
        bool isCorrect;

        public string AnswerText {
			get { return answerText; }
			set { SetProperty(ref answerText, value); }
		}

		public bool IsCorrect {
			get { return isCorrect; }
			set { SetProperty(ref isCorrect, value); }
		}
    }
}

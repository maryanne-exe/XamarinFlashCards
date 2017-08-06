namespace XamarinFlashCards
{
    public class Answer : ObservableObject
    {
        string answerText = string.Empty;
        public string AnswerText
		{
			get { return answerText; }
			set { SetProperty(ref answerText, value); }
		}

        bool isCorrect;
		public bool IsCorrect
		{
			get { return isCorrect; }
			set { SetProperty(ref isCorrect, value); }
		}
    }
}

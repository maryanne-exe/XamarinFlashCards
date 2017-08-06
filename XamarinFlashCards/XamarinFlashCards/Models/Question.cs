using System.Collections.Generic;

namespace XamarinFlashCards
{
    public class Question : ObservableObject
    {
        string questionText = string.Empty;
        public string QuestionText
		{
			get { return questionText; }
			set { SetProperty(ref questionText, value); }
		}

        IEnumerable<Answer> answers = new List<Answer> ();
        public IEnumerable<Answer> Answers
		{
			get { return answers; }
			set { SetProperty(ref answers, value); }
		}
	}
}

using System.Collections.Generic;

namespace XamarinFlashCards
{
    public class Question : ObservableObject
    {
        string questionText = string.Empty;
        string description = string.Empty;

        IEnumerable<Answer> answers = new List<Answer>();

        public string QuestionText {
			get { return questionText; }
			set { SetProperty(ref questionText, value); }
		}

        public IEnumerable<Answer> Answers {
			get { return answers; }
			set { SetProperty(ref answers, value); }
		}

		public string Description {
			get { return description; }
			set { SetProperty(ref description, value); }
		}
	}
}

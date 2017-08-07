using System.Collections.Generic;

using Newtonsoft.Json;

namespace XamarinFlashCards
{
    public class Chapter : ObservableObject
    {
		string id = string.Empty;
        string title = string.Empty;
        string description = string.Empty;

        IEnumerable<Question> questions = new List<Question>();

		[JsonIgnore]
		public string Id {
			get { return id; }
			set { SetProperty(ref id, value); }
		}

        public string Title {
			get { return title; }
			set { SetProperty(ref title, value); }
		}

		public string Description {
			get { return description; }
			set { SetProperty(ref description, value); }
		}

        public IEnumerable<Question> Questions {
			get { return questions; }
			set { SetProperty(ref questions, value); }
        }
    }
}

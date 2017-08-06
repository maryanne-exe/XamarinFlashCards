﻿using Newtonsoft.Json;

namespace XamarinFlashCards
{
    public class Chapter : ObservableObject
    {
		string id = string.Empty;

		[JsonIgnore]
		public string Id
		{
			get { return id; }
			set { SetProperty(ref id, value); }
		}

        string title = string.Empty;
        public string Title
		{
			get { return title; }
			set { SetProperty(ref title, value); }
		}

		string description = string.Empty;
		public string Description
		{
			get { return description; }
			set { SetProperty(ref description, value); }
		}
    }
}

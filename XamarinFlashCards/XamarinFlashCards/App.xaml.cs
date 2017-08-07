using System.Collections.Generic;

using Xamarin.Forms;

using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace XamarinFlashCards
{
    public partial class App : Application
    {
        public static bool UseLocalDataStore = true;
        public static string BackendUrl = "https://localhost:5000";
        public static IDictionary<string, string> LoginParameters => null;

        public App()
        {
            InitializeComponent();

            if (UseLocalDataStore)
                DependencyService.Register<LocalDataStore>();

            GoToMainPage();
        }

        public static void GoToMainPage()
        {
            Current.MainPage = new NavigationPage(new ChaptersPage());
        }

		protected override void OnStart()
		{
			MobileCenter.Start("ios=bd6d0ee7-2bcc-41ee-951f-dfc01bb46c51;" +
					   "uwp={Your UWP App secret here};" +
					   "android={Your Android App secret here}",
					   typeof(Analytics), typeof(Crashes));
		}
    }
}

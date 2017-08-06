using System.Collections.Generic;

using Xamarin.Forms;

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
    }
}

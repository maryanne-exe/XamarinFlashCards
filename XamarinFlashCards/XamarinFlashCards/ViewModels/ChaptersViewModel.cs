using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinFlashCards
{
    public class ChaptersViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Chapter> Chapters { get; set; }
        public Command LoadChaptersCommand { get; set; }

        public ChaptersViewModel()
        {
            Title = "Chapters";
            Chapters = new ObservableRangeCollection<Chapter>();
            LoadChaptersCommand = new Command(async () => await ExecuteLoadChaptersCommand());

            MessagingCenter.Subscribe<NewChapterPage, Chapter>(this, "AddChapter", async (obj, item) =>
            {
                var _item = item as Chapter;
                Chapters.Add(_item);
                await DataStore.AddItemAsync(_item);
            });
        }

        async Task ExecuteLoadChaptersCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Chapters.Clear();
                var chapters = await DataStore.GetItemsAsync(true);
                Chapters.ReplaceRange(chapters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load chapters.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

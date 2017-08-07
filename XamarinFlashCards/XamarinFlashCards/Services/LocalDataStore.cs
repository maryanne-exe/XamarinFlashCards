using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XamarinFlashCards
{
    public class LocalDataStore : IDataStore<Chapter>
    {
        readonly IEnumerable<Chapter> chapters;

        public LocalDataStore()
        {
            Stream stream = new FileStream("Chapters.json", FileMode.Open);

			using (var reader = new StreamReader(stream))
			{
				var json = reader.ReadToEnd();
                chapters = JsonConvert.DeserializeObject<IEnumerable<Chapter>>(json);
			}
        }

        public Task<bool> AddItemAsync(Chapter item)
        {
            if(item == null) {
                return Task.FromResult(false);
            }

            if(chapters.Any(c => c.Id == item.Id)) {
                return Task.FromResult(false);
            }

            (chapters as List<Chapter>).Add(item);

            return Task.FromResult(true);
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            if(string.IsNullOrEmpty(id)) {
                return Task.FromResult(false);
            }

            var chapter = chapters.FirstOrDefault(c => c.Id == id);

            if(chapter == null) {
                return Task.FromResult(false);
            }

            (chapters as List<Chapter>).Remove(chapter);
            return Task.FromResult(true);
        }

        public Task<Chapter> GetItemAsync(string id)
        {
			if (string.IsNullOrEmpty(id)) {
                return Task.FromResult(null as Chapter);
			}

            var chapter = chapters.FirstOrDefault(c => c.Id == id);

            return Task.FromResult(chapter);
        }

        public Task<IEnumerable<Chapter>> GetItemsAsync(bool forceRefresh = false)
        {
            return Task.FromResult(chapters);
        }

        public Task<bool> UpdateItemAsync(Chapter item)
        {
			if (item == null) {
				return Task.FromResult(false);
			}

            var chapter = chapters.FirstOrDefault(c => c.Id == item.Id);
            if (chapter != null) {
                (chapters as List<Chapter>).Remove(chapter);
                (chapters as List<Chapter>).Add(item);

                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}

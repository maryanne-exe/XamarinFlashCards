using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XamarinFlashCards
{
    public class LocalDataStore : IDataStore<Chapter>
    {
        IEnumerable<Chapter> chapters;

        public LocalDataStore()
        {
            chapters = new List<Chapter> {
                new Chapter {
                    Title = "Xamarin",
                    Description = "Learn Xamarin with cards!"
                }
            };
        }

        public Task<bool> AddItemAsync(Chapter item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Chapter> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Chapter>> GetItemsAsync(bool forceRefresh = false)
        {
            return Task.FromResult(chapters);
        }

        public Task<bool> UpdateItemAsync(Chapter item)
        {
            throw new NotImplementedException();
        }
    }
}

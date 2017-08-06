using System;
using System.Linq;
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
                },
                new Chapter {
                    Title = "Azure",
                    Description = "Learn Azure with cards!"
                },
                new Chapter {
                    Title = "C#",
                    Description = "Learn C# with cards!"
                }
            };
        }

        public Task<bool> AddItemAsync(Chapter item)
        {
            if(item == null) {
                return Task.FromResult(false);
            }

            if(chapters.Where(chapter => chapter.Id == item.Id).Any()) {
                return Task.FromResult(false);
            }

            (chapters as List<Chapter>).Add(item);

            return Task.FromResult(true);
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

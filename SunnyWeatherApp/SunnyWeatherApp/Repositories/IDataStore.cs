using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SunnyWeatherApp.Models.Location;

namespace SunnyWeatherApp.Repositories
{
    public interface IDataStore<T>
    {
        Location GetItem(string id);
        IEnumerable<T> GetItemList();
        Task<bool> AddOrUpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
    }
}

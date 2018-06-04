using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SunnyWeatherApp.Models.Location;

namespace SunnyWeatherApp.Services.Abstractions
{
    public interface ILocationSearchService
    {
        Task<IList<Location>> GetLocationListByTextAsync(string searchText);
        Task<bool> AddItemAsync(Location location);
        Task<bool> DeleteItemAsync(string key);
        Task<Location> GetItemAsync(string key);
        Task<IEnumerable<Location>> GetItemListAsync(bool forceRefresh = false);
    }
}


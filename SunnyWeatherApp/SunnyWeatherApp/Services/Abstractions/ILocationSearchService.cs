using System.Collections.Generic;
using System.Threading.Tasks;
using SunnyWeatherApp.Models.Location;

namespace SunnyWeatherApp.Services.Abstractions
{
    public interface ILocationSearchService
    {
        IEnumerable<Location> GetLocationList();

        Task<IList<Location>> GetLocationListByTextAsync(string searchText);

        Location GetLocation(string key);

        Task<bool> AddLocationAsync(Location location);

        Task<bool> DeleteLocationAsync(string key);
    }
}


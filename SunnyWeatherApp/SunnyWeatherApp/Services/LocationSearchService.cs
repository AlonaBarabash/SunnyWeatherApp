using System.Collections.Generic;
using System.Threading.Tasks;
using SunnyWeatherApp.Models.Location;
using SunnyWeatherApp.Repositories;
using SunnyWeatherApp.Repositories.AccuWeatherRepositories.Abstractions;
using SunnyWeatherApp.Services.Abstractions;

namespace SunnyWeatherApp.Services
{
    class LocationSearchService : ILocationSearchService
    {
        private readonly ILocationAccuWeatherRepository _locationRepository;
        private readonly IDataStore<Location> _locationDataStoreRepository;


        public LocationSearchService(ILocationAccuWeatherRepository locationRepository,
            IDataStore<Location> locationDataStoreRepository)
        {
            _locationRepository = locationRepository;
            _locationDataStoreRepository = locationDataStoreRepository;
        }

        public async Task<IList<Location>> GetLocationListByTextAsync(string searchText)
        {
            return await _locationRepository.GetLocationListByTextAsync(searchText);
        }

        public async Task<bool> AddLocationAsync(Location location)
        {
            return await _locationDataStoreRepository.AddOrUpdateItemAsync(location);
        }

        public async Task<bool> DeleteLocationAsync(string key)
        {
            return await _locationDataStoreRepository.DeleteItemAsync(key);
        }

        public Location GetLocation(string key)
        {
            return _locationDataStoreRepository.GetItem(key);
        }

        public IEnumerable<Location> GetLocationList()
        {
            return _locationDataStoreRepository.GetItemList();
        }
    }
}
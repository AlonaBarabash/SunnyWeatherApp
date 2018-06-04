using System;
using System.Collections.Generic;
using System.Text;
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


        public LocationSearchService(ILocationAccuWeatherRepository locationRepository, IDataStore<Location> locationDataStoreRepository)
        {
            _locationRepository = locationRepository;
            _locationDataStoreRepository = locationDataStoreRepository;
        }

        public async Task<IList<Location>> GetLocationListByTextAsync(string searchText)
        {
            return await _locationRepository.GetLocationListByTextAsync(searchText);
        }

        public async Task<bool> AddItemAsync(Location location)
        {
            return await _locationDataStoreRepository.AddItemAsync(location);
        }

        public async Task<bool> DeleteItemAsync(string key)
        {
            return await _locationDataStoreRepository.DeleteItemAsync(key);
        }

        public async Task<Location> GetItemAsync(string key)
        {
            return await _locationDataStoreRepository.GetItemAsync(key);
        }

        public async Task<IEnumerable<Location>> GetItemListAsync(bool forceRefresh = false)
        {
            return await _locationDataStoreRepository.GetItemListAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SunnyWeatherApp.Models.Location;
using Xamarin.Forms;

namespace SunnyWeatherApp.Repositories
{
    class LocationDataStoreRepository : IDataStore<Location>
    {
        private const string KeyPrefix = "location_key_";

        private IEnumerable<Location> _locationList;

        public LocationDataStoreRepository()
        {
            _locationList = Application.Current.Properties
                .Where(x => x.Key.Contains($"{KeyPrefix}"))
                .Select(x => JsonConvert.DeserializeObject<Location>(x.Value.ToString()));
        }

        public async Task<bool> AddItemAsync(Location location)
        {
            if (Application.Current.Properties.Keys.Contains($"{KeyPrefix}{location.Key}"))
            {
                await DeleteItemAsync(location.Key);
            }
            Application.Current.Properties.Add($"{KeyPrefix}{location.Key}", JsonConvert.SerializeObject(location));
            await Application.Current.SavePropertiesAsync();
            return true;
        }

        public async Task<bool> DeleteItemAsync(string key)
        {
            Application.Current.Properties.Remove($"{KeyPrefix}{key}");
            await Application.Current.SavePropertiesAsync();
            await GetItemListAsync();
            return true;
        }

        public async Task<Location> GetItemAsync(string key)
        {
            return await Task.FromResult(_locationList.FirstOrDefault(s => s.Key == key));
        }

        public async Task<IEnumerable<Location>> GetItemListAsync(bool forceRefresh = false)
        {
            _locationList = Application.Current.Properties
                .Where(x => x.Key.Contains($"{KeyPrefix}"))
                .Select(x => JsonConvert.DeserializeObject<Location>(x.Value.ToString()));

            return await Task.FromResult(_locationList);
        }
    }
}

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
   public class LocationDataStoreRepository : BaseDataStoreRepository<Location>, IDataStore<Location>
    {
        protected override string ItemKeyPrefix => "location_key_";

        protected override Func<Location, string> KeyPredicate =>
            location => location.Key;

        public async Task<bool> AddOrUpdateItemAsync(Location location)
        {
            if (CheckIfExist(location))
            {
                await UpdateStorageAsync(location);
            }
            else
            {
                await AddToStorageAsync(location);
            }

            return true;
        }

        public async Task<bool> DeleteItemAsync(string key)
        {
            await DeleteFromStorageAsync(key);
            return true;
        }

        public Location GetItem(string key)
        {
            return GetItemFromStorage(key);
        }

        public IEnumerable<Location> GetItemList()
        {
            return GetItemListFromStorage();
        }
    }
}
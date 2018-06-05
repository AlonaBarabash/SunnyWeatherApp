using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace SunnyWeatherApp.Repositories
{
    public abstract class BaseDataStoreRepository<T>
    {
        protected BaseDataStoreRepository()
        {
            Properties = Application.Current.Properties;
        }

        protected abstract string ItemKeyPrefix { get; }

        protected abstract Func<T, string> KeyPredicate { get; }

        protected IDictionary<string, object> Properties { get; }

        protected bool CheckIfExist(T item)
        {
            var key = GetFullKey(item);

            return Properties.Any(x => x.Key.Equals(key));
        }

        public IList<T> GetItemListFromStorage()
        {
            return Properties
                .Where(x => x.Key.StartsWith($"{ItemKeyPrefix}"))
                .Select(x => JsonConvert.DeserializeObject<T>(x.Value.ToString()))
                .ToList();
        }

        public T GetItemFromStorage(string itemKey)
        {
            var key = GetFullKey(itemKey);

            var keyValue = Properties.Single(x => x.Key.Equals(key));
            var item = JsonConvert.DeserializeObject<T>(keyValue.Value.ToString());
            return item;
        }

        protected async Task AddToStorageAsync(T item)
        {
            var key = GetFullKey(item);

            Properties.Add(key, JsonConvert.SerializeObject(item));
            await Application.Current.SavePropertiesAsync();
        }

        protected async Task UpdateStorageAsync(T item)
        {
            var key = GetFullKey(item);

            Properties.Remove(key);
            Properties.Add(key, JsonConvert.SerializeObject(item));
            await Application.Current.SavePropertiesAsync();
        }

        protected async Task DeleteFromStorageAsync(T item)
        {
            var key = GetFullKey(item);

            Properties.Remove(key);
            await Application.Current.SavePropertiesAsync();
        }

        protected async Task DeleteFromStorageAsync(string itemKey)
        {
            var key = GetFullKey(itemKey);

            Properties.Remove(key);
            await Application.Current.SavePropertiesAsync();
        }

        private string GetFullKey(string itemKey)
        {
            var key = $"{ItemKeyPrefix}{itemKey}";
            return key;
        }

        private string GetFullKey(T item)
        {
            var itemKey = KeyPredicate(item);
            return GetFullKey(itemKey);
        }
    }
}

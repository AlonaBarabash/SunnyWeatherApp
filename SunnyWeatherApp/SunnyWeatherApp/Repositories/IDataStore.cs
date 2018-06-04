﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SunnyWeatherApp.Repositories
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemListAsync(bool forceRefresh = false);
    }
}
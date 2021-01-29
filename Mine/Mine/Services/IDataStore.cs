﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mine.Services
{
    public interface IDataStore<T>
    {
        Task<bool> CreateAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}

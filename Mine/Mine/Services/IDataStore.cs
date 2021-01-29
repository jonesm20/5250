﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mine.Services
{
    public interface IDataStore<T>
    {
        Task<bool> CreateAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(string id);
        Task<T> IndexAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}

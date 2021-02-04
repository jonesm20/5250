using System;
using System.Linq;
using System.Threading.Tasks;

using SQLite;

using Mine.Models;
using System.Collections.Generic;

namespace Mine.Services
{
    public class DatabaseService : IDataStore<ItemModel>
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public DatabaseService()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ItemModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(ItemModel)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        /// <summary>
        /// This method creates an item if it doesn't exist in the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(ItemModel item)
        {
            if (item == null)
            {
                return false;
            }

            var result = await Database.InsertAsync(item);
            if (result == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// This method reads from the database based on the given id if the item
        /// exists in the database already
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<ItemModel> ReadAsync(string id)
        {
            if (id == null)
            {
                return null;
            }

            var result = Database.Table<ItemModel>().FirstOrDefaultAsync(m => m.Id.Equals(id));
            return result;
        }

        /// <summary>
        /// This method updates an item if it is found in the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Task<bool> UpdateAsync(ItemModel item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method deletes an item from the database if it already exists. Found
        /// by the given id of the item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ItemModel>> IndexAsync(bool forceRefresh = false)
        {
            var result = await Database.Table<ItemModel>().ToListAsync();
            return result;
        }

        /// <summary>
        /// This method gets items from the database
        /// </summary>
        /// <param name="forceRefresh"></param>
        /// <returns></returns>
        public Task<IEnumerable<ItemModel>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        Task<ItemModel> IDataStore<ItemModel>.IndexAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}

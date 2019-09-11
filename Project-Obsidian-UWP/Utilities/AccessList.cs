using System;
using System.Threading.Tasks;
using Windows.Storage;

namespace Project_Obsidian_UWP.Utilities
{
    public class AccessList
    {
        // Add Folder or File to the Most Recent Used List and persist it.
        public static void AddMRUList(IStorageItem item, string metaData = "New Storage Item", string persistenceId = null)
        {
            var mru = Windows.Storage.AccessCache.StorageApplicationPermissions.MostRecentlyUsedList;
            string mruToken = mru.Add(item, metaData);
            
            if (persistenceId != null)
            {
                Persistent.SaveSettings(persistenceId, mruToken);
            }
        }

        // Get item from MRU list
        public async static Task<IStorageItem> GetFromMRUList(string token)
        {
            var mru = Windows.Storage.AccessCache.StorageApplicationPermissions.MostRecentlyUsedList;

            if (mru.ContainsItem(token))
            {
                return await mru.GetItemAsync(token);
            }
            return null;
        }

        #region Unfinished API
        public static void AddFutureList(IStorageFile item, string metaData = "New Storage Item")
        {
            var futureList = Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList;
            string futureToken = futureList.Add(item, metaData);
        }

        public async static Task<IStorageItem> GetFromFutureList(string token)
        {
            var futureList = Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList;

            if (futureList.ContainsItem(token))
            {
                return await futureList.GetItemAsync(token);
            }
            return null;
        }
        #endregion
    }
}

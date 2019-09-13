using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Project_Obsidian_UWP.Core
{
    public class Loader
    {
        public async static Task ReadAllCategories(StorageFolder rootFolder)
        {
            StorageFolder cateFolder = await rootFolder.GetFolderAsync("_featured_categories");
        }
    }
}

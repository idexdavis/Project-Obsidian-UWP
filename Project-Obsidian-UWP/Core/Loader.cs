using LunarLabs.Parser;
using Project_Obsidian_UWP.Models;
using Project_Obsidian_UWP.Utilities;
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
            StorageFolder cateFolder = await rootFolder.GetFolderAsync(Constants.categoriesPath);
            if (cateFolder != null)
            {
                IReadOnlyList<StorageFile> storageFiles = await cateFolder.GetFilesAsync();

                if (storageFiles == null) return;

                foreach (StorageFile file in storageFiles)
                {
                    DataNode root = await Parser.ParseYAMLFront(file);
                    isLayoutValid(file, root);

                    Category category = new Category(file.Name,
                                                     root.GetString(Constants.titleKeyword),
                                                     root.GetString(Constants.slugKeyword),
                                                     root.GetString(Constants.descriptionKeyword),
                                                     file.Path);
                    Core.categoryList.AddCategory(category);
                }
            }
        }

        private static bool isLayoutValid(StorageFile file, DataNode root)
        {
            if (root.GetString(Constants.layoutKeyword) != Enumerations.CategoryLayout.List.ToString().ToLower())
            {
                Console.WriteLine($"Category { file.Name } layout is incorrect!");
                return false;
            }
            return true;
        }
    }
}

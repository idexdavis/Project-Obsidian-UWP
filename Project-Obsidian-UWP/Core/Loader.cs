using LunarLabs.Parser;
using Project_Obsidian_UWP.Models;
using Project_Obsidian_UWP.Utilities;
using System;
using System.Collections.Generic;
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
                    var splitedContent = await Utility.SplitYAMLFrontMatter(file);
                    DataNode root = Parser.ParseYAMLFront(splitedContent.Item1);

                    isLayoutValid(file, root);

                    Category category = new Category(file.Name,
                                                     root.GetString(Constants.titleKeyword),
                                                     root.GetString(Constants.slugKeyword),
                                                     root.GetString(Constants.descriptionKeyword),
                                                     file.Path, content: splitedContent.Item2);
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

using Project_Obsidian_UWP.Models;
using Project_Obsidian_UWP.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using YamlDotNet.RepresentationModel;

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
                    //var splitedContent = await Utility.SplitYAMLFrontMatter(file);
                    string content = await FileIO.ReadTextAsync(file);
                    (YamlMappingNode, string) roots = Parser.ParseYamlFront(content);

                    isLayoutValid(file, roots.Item1);

                    Category category = new Category(file.Name,
                                                     (string)roots.Item1.Children[new YamlScalarNode(Constants.titleKeyword)],
                                                     (string)roots.Item1.Children[new YamlScalarNode(Constants.slugKeyword)],
                                                     (string)roots.Item1.Children[new YamlScalarNode(Constants.descriptionKeyword)],
                                                     file.Path);
                    Core.categoryList.AddCategory(category);
                }
            }
        }

        private static bool isLayoutValid(StorageFile file, YamlMappingNode root)
        {
            if ((string)root.Children[new YamlScalarNode(Constants.layoutKeyword)] != 
                Enumerations.CategoryLayout.List.ToString().ToLower())
            {
                Console.WriteLine($"Category { file.Name } layout is incorrect!");
                return false;
            }
            return true;
        }
    }
}

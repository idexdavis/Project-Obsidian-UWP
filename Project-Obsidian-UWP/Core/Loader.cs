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
                    IDictionary<YamlNode, YamlNode> children = Parser.ParseYamlFront(content).Children;

                    isLayoutValid(file, children);

                    Category category = new Category(file.Name,
                                                     (string)children[new YamlScalarNode(Constants.titleKeyword)],
                                                     (string)children[new YamlScalarNode(Constants.slugKeyword)],
                                                     (string)children[new YamlScalarNode(Constants.descriptionKeyword)],
                                                     file.Path);
                    Core.categoryList.AddCategory(category);
                }
            }
        }

        private static bool isLayoutValid(StorageFile file, IDictionary<YamlNode, YamlNode> children)
        {
            if ((string)children[new YamlScalarNode(Constants.layoutKeyword)] != 
                Enumerations.CategoryLayout.List.ToString().ToLower())
            {
                Console.WriteLine($"Category { file.Name } layout is incorrect!");
                return false;
            }
            return true;
        }
    }
}

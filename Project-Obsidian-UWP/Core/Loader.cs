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
                    var splitedContent = await Utility.SplitYamlFrontMatter(file);
                    IDictionary<YamlNode, YamlNode> children = Parser.ParseYamlFront(splitedContent.Item1).Children;

                    isLayoutValid(file, children);

                    Category category = new Category(file.DisplayName, file.FileType,
                                                     (string)children[new YamlScalarNode(Constants.titleKeyword)],
                                                     (string)children[new YamlScalarNode(Constants.slugKeyword)],
                                                     (string)children[new YamlScalarNode(Constants.descriptionKeyword)],
                                                     file.Path, content: splitedContent.Item2);
                    Core.categoryManager.AddCategoryCollection(category);
                }
            }
        }

        public async static Task ReadAllPosts(StorageFolder rootFolder)
        {
            StorageFolder postsFolder = await rootFolder.GetFolderAsync(Constants.postsPath);

            foreach (Category category in Core.categoryManager.GetCategoriesCollection())
            {
                try
                {
                    StorageFolder singlePostsFolder = await postsFolder.GetFolderAsync($"{ category.slug }\\{ Constants.subpostPath }");
                    IReadOnlyList<StorageFile> postFiles = await singlePostsFolder.GetFilesAsync();
                    foreach (StorageFile postFile in postFiles)
                    {
                        var splitedContent = await Utility.SplitYamlFrontMatter(postFile);
                        IDictionary<YamlNode, YamlNode> children = Parser.ParseYamlFront(splitedContent.Item1).Children;

                        string title = (string)children[new YamlScalarNode(Constants.titleKeyword)];
                        string description = (string)children[new YamlScalarNode(Constants.descriptionKeyword)];

                        Post post = new Post(postFile.DisplayName, 
                                             postFile.FileType, 
                                             title, description, 
                                             postFile.Path ,
                                             category,
                                             splitedContent.Item2);

                        category.posts.AddPost(post);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Category doesn't match up posts or cannot locate _posts folder. Detail: { ex.Message }");
                }
            }
        }

        public async static Task ReadAllPages(StorageFolder rootFolder)
        {
            StorageFolder pagesFolder = await rootFolder.GetFolderAsync(Constants.pagesPath);

            foreach (StorageFile pageFile in await pagesFolder.GetFilesAsync())
            {
                var splitedContent = await Utility.SplitYamlFrontMatter(pageFile);
                IDictionary<YamlNode, YamlNode> children = Parser.ParseYamlFront(splitedContent.Item1).Children;

                string title = (string)children[new YamlScalarNode(Constants.titleKeyword)];
                string description = (string)children[new YamlScalarNode(Constants.descriptionKeyword)];
                string layout = (string)children[new YamlScalarNode(Constants.layoutKeyword)];
                string permalink = (string)children[new YamlScalarNode(Constants.permalinkKeyword)];

                Page page = new Page(layout, 
                                     permalink, 
                                     pageFile.DisplayName, 
                                     pageFile.FileType,
                                     title, 
                                     description, 
                                     splitedContent.Item2);

                Core.pageManager.AddPageCollection(page);
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

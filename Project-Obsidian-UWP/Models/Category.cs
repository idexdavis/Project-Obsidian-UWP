using System.Collections.Generic;
using System.Collections.ObjectModel;
using static Project_Obsidian_UWP.Utilities.Enumerations;
using static Project_Obsidian_UWP.Utilities.Utility;

namespace Project_Obsidian_UWP.Models
{
    // This class is made for storing category info
    // by scanning category files located in folder
    // "/_featured_categories"
    public class Category
    {
        public string fileName { get; set; }
        public string fileExt { get; set; }
        public CategoryLayout layout { get; set; }
        public string title { get; set; }
        public string slug { get; set; }
        public string description { get; set; }
        public string filePath { get; set; }
        public string content { get; set; }
        public PostsManager posts { get; set; }

        public Category(string fileFullName, string title, string slug,
                        string description, string filePath,
                        string content = "",
                        CategoryLayout layout = CategoryLayout.List)
        {
            var fileNameAndExt = SplitFileName(fileFullName);
            this.fileName = fileNameAndExt.Item1; this.fileExt = fileNameAndExt.Item2;
            this.layout = layout;
            this.title = title;
            this.slug = slug;
            this.description = description;
            this.filePath = filePath;
            this.content = content;
        }
    }

    public class CategoryManager
    {
        private ObservableCollection<Category> _categories = new ObservableCollection<Category>();

        public void AddCategory(Category category)
        {
            _categories.Add(category);
        }

        public void AddCategories(List<Category> categories)
        {
            foreach (Category category in categories)
            {
                _categories.Add(category);
            }
        }

        public ObservableCollection<Category> GetCategories()
        {
            return _categories;
        }

        public void MoveCategory(int oldIndex, int newIndex)
        {
            _categories.Move(oldIndex, newIndex);
        }
    }
}

using System.Collections.Generic;
using System.Collections.ObjectModel;
using static Project_Obsidian_UWP.Utilities.Enumerations;

namespace Project_Obsidian_UWP.Models
{
    // This class is made for storing category info
    // by scanning category files located in folder
    // "/_featured_categories"
    public class Category
    {
        public string fullFileName
        {
            get { return fileName + fileExt; }
        }
        public string fileName { get; set; }
        public string fileExt { get; set; }
        public CategoryLayout layout { get; set; }
        public string title { get; set; }
        public string slug { get; set; }
        public string description { get; set; }
        public string filePath { get; set; }
        public string content { get; set; }

        public PostsManager posts = new PostsManager();

        public Category(string fileName, string fileExt, string title, string slug,
                        string description, string filePath,
                        string content = "",
                        CategoryLayout layout = CategoryLayout.List)
        {
            this.fileName = fileName; this.fileExt = fileExt;
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
        private List<Category> _categoryList = new List<Category>();
        private ObservableCollection<Category> _categoryCollection = new ObservableCollection<Category>();

        public void AddCategoryCollection(Category category)
        {
            _categoryCollection.Add(category);
        }

        public void AddCategoryList(Category category)
        {
            _categoryList.Add(category);
        }

        public void AddCategoriesCollection(List<Category> categories)
        {
            foreach (Category category in categories)
            {
                _categoryCollection.Add(category);
            }
        }

        public void AddCategoriesList(List<Category> categories)
        {
            _categoryList.AddRange(categories);
        }

        public ObservableCollection<Category> GetCategoriesCollection()
        {
            return _categoryCollection;
        }

        public List<Category> GetCategoriesList()
        {
            return _categoryList;
        }

        public void MoveCategory(int oldIndex, int newIndex)
        {
            _categoryCollection.Move(oldIndex, newIndex);
        }
    }
}

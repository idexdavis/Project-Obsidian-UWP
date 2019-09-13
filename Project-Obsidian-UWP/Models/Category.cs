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

        public Category(string fileFullName, string title, string slug,
                        string description, string filePath,
                        CategoryLayout layout = CategoryLayout.list)
        {
            var fileNameAndExt = SplitFileName(fileFullName);
            this.fileName = fileNameAndExt.Item1; this.fileExt = fileNameAndExt.Item2;
            this.layout = layout;
            this.title = title;
            this.slug = slug;
            this.description = description;
            this.filePath = filePath;
        }
    }
}

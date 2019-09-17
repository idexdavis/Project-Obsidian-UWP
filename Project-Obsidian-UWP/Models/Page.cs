using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project_Obsidian_UWP.Utilities.Enumerations;

namespace Project_Obsidian_UWP.Models
{
    public class Page
    {
        public PageLayout layout { get; set; }
        public DateTime createDate { get; set; }
        public string fileName { get; set; }
        public string fileExt { get; set; }
        public string fullFileName
        {
            get { return fileName + fileExt; }
        }
        public string title { get; set; }
        public string description { get; set; }
        public string permalink { get; set; }
        public string content { get; set; }

        public Page(string layout, string permalink, string fileName, string fileExt,
                    string title = "", string description = "", string content = "")
        {
            this.layout = Utilities.Utility.StrToPageLayout(layout);
            this.permalink = permalink;
            this.fileName = fileName;
            this.fileExt = fileExt;
            this.title = title;
            this.description = description;
            this.content = content;
        }
    }
}

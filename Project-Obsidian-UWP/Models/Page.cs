using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public class PageManager
    {
        private List<Page> _pageList = new List<Page>();
        private ObservableCollection<Page> _pageCollection = new ObservableCollection<Page>();

        public void AddPageCollection(Page page)
        {
            _pageCollection.Add(page);
        }

        public void AddPageList(Page page)
        {
            _pageList.Add(page);
        }

        public void AddPagesCollection(List<Page> pages)
        {
            foreach (Page page in pages)
            {
                _pageCollection.Add(page);
            }
        }

        public void AddPagesList(List<Page> pages)
        {
            _pageList.AddRange(pages);
        }

        public ObservableCollection<Page> GetPagesCollection()
        {
            return _pageCollection;
        }

        public List<Page> GetPagesList()
        {
            return _pageList;
        }

        public void MovePage(int oldIndex, int newIndex)
        {
            _pageCollection.Move(oldIndex, newIndex);
        }
    }
}

using Project_Obsidian_UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Obsidian_UWP.Core
{
    public class Core
    {
        public static CategoryManager categoryManager = new CategoryManager();
        public static PageManager pageManager = new PageManager();
        public static Windows.Storage.StorageFolder rootFolder { get; set; }
    }
}

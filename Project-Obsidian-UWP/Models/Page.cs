using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Obsidian_UWP.Models
{
    public class Page
    {
        public DateTime createDate { get; set; }
        public string fileName { get; set; }
        public string fileExt { get; set; }
        public string fullFileName { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string permalink { get; set; }
        public string content { get; set; }
    }
}

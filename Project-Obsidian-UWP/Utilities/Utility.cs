using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Obsidian_UWP.Utilities
{
    public class Utility
    {
        // Split file name and file extension based on a full file name.
        public static (string, string) SplitFileName(string fileFullName)
        {
            if (!string.IsNullOrEmpty(fileFullName))
            {
                List<string> splitedName = fileFullName.Split('.', count: 2)?.ToList();
                if (splitedName != null && splitedName.Count() == 2)
                {
                    return (splitedName[0], splitedName[1]);
                }
            }
            return (null, null);
            // throw new Exception("Fail to split file name and extension.");
        }
    }
}

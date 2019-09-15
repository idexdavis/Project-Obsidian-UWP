using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;

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

        // This API is not ready for production use.
        // TODO: Refine the algorithm.
        public async static Task<(string, string)> SplitYamlFrontMatter(StorageFile file)
        {
            List<string> lines = (await FileIO.ReadLinesAsync(file)).ToList();

            int index = 0;
            foreach (string line in lines)
            {
                if (index != 0 && line.StartsWith("---"))
                    break;

                if (index == 0 && !line.StartsWith("---"))
                {
                    throw new Exception($"YAML Front Matter in { file.Name } is incorrect. File path: { file.Path }");
                }
                index++;
            }

            return (string.Join("\r\n", lines.GetRange(0, index + 1)), 
                    string.Join("\r\n", lines.GetRange(index + 1, lines.Count() - index - 1)));
        }
    }
}

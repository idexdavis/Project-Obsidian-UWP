using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunarLabs.Parser;
using LunarLabs.Parser.YAML;
using Project_Obsidian_UWP.Models;
using Windows.Storage;

namespace Project_Obsidian_UWP.Core
{
    public class Parser
    {
        public static DataNode ParseYAMLFront(string yaml)
        {
            return YAMLReader.ReadFromString(yaml);
        }

        public async static Task<DataNode> ParseYAMLFile(StorageFile file)
        {
            string content = await FileIO.ReadTextAsync(file);
            return YAMLReader.ReadFromString(content);
        }

        // Try not to use this API for the concern of efficiency
        // if you need to call this function oftenly
        //public async static Task<string> GetStringFromYAML(StorageFile file, string key)
        //{
        //    return ParseYAMLFront(file).GetString(key);
        //}
    }
}

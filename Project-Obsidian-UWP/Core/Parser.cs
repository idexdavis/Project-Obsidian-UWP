using System;
using System.Threading.Tasks;
using YamlDotNet;
using Windows.Storage;
using YamlDotNet.RepresentationModel;
using System.IO;

namespace Project_Obsidian_UWP.Core
{
    public class Parser
    {
        public static YamlMappingNode ParseYAMLFront(string input)
        {
            var reader = new StringReader(input);
            var yamlStream = new YamlStream();
            yamlStream.Load(reader);

            return (YamlMappingNode)yamlStream.Documents[0].RootNode;
        }

        //public async static Task<DataNode> ParseYAMLFile(StorageFile file)
        //{
        //    string content = await FileIO.ReadTextAsync(file);
        //    return YAMLReader.ReadFromString(content);
        //}

        // Try not to use this API for the concern of efficiency
        // if you need to call this function oftenly
        //public async static Task<string> GetStringFromYAML(StorageFile file, string key)
        //{
        //    return ParseYAMLFront(file).GetString(key);
        //}
    }
}

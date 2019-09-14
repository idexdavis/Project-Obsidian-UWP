using YamlDotNet.RepresentationModel;
using System.IO;
using System.Collections.Generic;

namespace Project_Obsidian_UWP.Core
{
    public class Parser
    {
        public static IList<YamlDocument> ParseYamlFile(string input)
        {
            YamlStream yamlStream = ParseYamlCore(input);
            return yamlStream.Documents;
        }

        public static YamlMappingNode ParseYamlFront(string input)
        {
            IList<YamlDocument> yamlDoc = ParseYamlFile(input);

            return (YamlMappingNode)yamlDoc[0].RootNode;
        }

        private static YamlStream ParseYamlCore(string input)
        {
            var reader = new StringReader(input);
            var yamlStream = new YamlStream();
            yamlStream.Load(reader);
            return yamlStream;
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

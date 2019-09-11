using Project_Obsidian_UWP.Utilities;
using System;
using System.Threading.Tasks;
using Windows.Storage;
using Salaros.Configuration;

namespace Project_Obsidian_UWP.Core
{
    public class DefineLocation
    {
        // Locate the blog folder and check whether it is a valid location.
        public async static Task LocateAndCheckRepo()
        {
            StorageFolder pickedFolder = await Picker.PickFolder();
            
            if (pickedFolder != null)
            {
                await CheckConfigFile(pickedFolder);
            }
        }

        // Verify whether user locate the right location of blog folder.
        // Used Salaros.ConfigParser to parse config file.
        // https://github.com/salaros/config-parser for docs.
        private static async Task CheckConfigFile(StorageFolder pickedFolder)
        {
            try
            {
                StorageFile configFile = await pickedFolder.GetFileAsync("config.ini");
                string configText = await FileIO.ReadTextAsync(configFile);
                var parsedConfig = new ConfigParser(configText);

                bool isValid = parsedConfig["remote"]["url"] == Constants.configUrl &&
                               parsedConfig["info"]["version"] == Constants.configOrg;

                if (!isValid)
                {
                    // May find the folder but the config file doesn't match.
                    throw new Exception("Cannot verify the the blog as the config file doesn't match.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot locate your blog folder. Error: { ex.Message }");
            }
        }
    }
}

using Project_Obsidian_UWP.Utilities;
using System;
using System.Threading.Tasks;
using Windows.Storage;
using Salaros.Configuration;
using System.Collections.ObjectModel;
using Project_Obsidian_UWP.Models;

namespace Project_Obsidian_UWP.Core
{
    public class DefineLocation
    {
        // Locate the blog folder and check whether it is a valid location.
        public async static Task<bool> LocateAndCheckRepo()
        {
            StorageFolder pickedFolder = await Picker.PickFolder();

            //await Loader.ReadAllCategories(pickedFolder);
            //await Loader.ReadAllPosts(pickedFolder);

            //var test = Core.categoryManager.GetCategoriesCollection();

            if (pickedFolder != null)
            {
                return await CheckConfigFile(pickedFolder);
            }
            return false;
        }

        // Verify whether user locate the right location of blog folder.
        // Used Salaros.ConfigParser to parse config file.
        // https://github.com/salaros/config-parser for docs.
        private static async Task<bool> CheckConfigFile(StorageFolder pickedFolder)
        {
            try
            {
                StorageFile configFile = await pickedFolder.GetFileAsync("config.ini");
                string configText = await FileIO.ReadTextAsync(configFile);
                var parsedConfig = new ConfigParser(configText);

                bool isValid = parsedConfig["remote"]["url"] == Constants.configUrl &&
                               parsedConfig["info"]["org"] == Constants.configOrg;

                if (!isValid)
                {
                    // May find the folder but the config file doesn't match.
                    throw new Exception("Cannot verify the the blog as the config file doesn't match.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot locate your blog folder. Error: { ex.Message }");
                return false;
            }

            return true;
        }
    }
}

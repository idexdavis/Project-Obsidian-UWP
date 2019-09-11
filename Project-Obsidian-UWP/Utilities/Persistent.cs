using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Project_Obsidian_UWP.Utilities
{
    // This class is created for persistence. Save and load user data from UWP container
    public class Persistent
    {
        public static void SaveSettings(string id, string content)
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Values[id] = content;
        }

        public static Object RetrieveSettings(string id)
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            return localSettings.Values[id];
        }
    }
}

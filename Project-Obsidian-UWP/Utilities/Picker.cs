using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Pickers;

namespace Project_Obsidian_UWP.Utilities
{
    // This class is created for facilitating calling file picker.
    public class Picker
    {
        public async static void PickFolder(string metaData = null,
                                            PickerLocationId pickerLocationId = PickerLocationId.Desktop)
        {
            var folderPicker = new FolderPicker();
            folderPicker.SuggestedStartLocation = pickerLocationId;
            folderPicker.FileTypeFilter.Add("*");

            Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                // Application now has read/write access to all contents in the picked folder
                // (including other sub-folder contents)
                AccessList.AddMRUList(folder, metaData);
            }
            else
            {
                Console.WriteLine("Operation Cancelled");
            }
        }

        public async static void PickFiles(List<string> fileTypes,
                                           string metaData = "New Storage Item",
                                           PickerViewMode pickerViewMode = PickerViewMode.Thumbnail,
                                           PickerLocationId pickerLocationId = PickerLocationId.PicturesLibrary)
        {
            var picker = new FileOpenPicker();
            picker.ViewMode = pickerViewMode;
            picker.SuggestedStartLocation = pickerLocationId;

            foreach (string type in fileTypes)
            {
                picker.FileTypeFilter.Add(type);
            }

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
            }
        }
    }
}

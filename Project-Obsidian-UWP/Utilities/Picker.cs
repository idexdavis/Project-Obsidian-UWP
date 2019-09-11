using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.Storage;

namespace Project_Obsidian_UWP.Utilities
{
    // This class is created for facilitating calling file picker.
    public class Picker
    {
        public async static Task<StorageFolder> PickFolder(PickerLocationId pickerLocationId = PickerLocationId.Desktop)
        {
            var folderPicker = new FolderPicker();
            folderPicker.SuggestedStartLocation = pickerLocationId;
            folderPicker.FileTypeFilter.Add("*");

            StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                // Application now has read/write access to all contents in the picked folder
                // (including other sub-folder contents)
                return folder;
            }

            Console.WriteLine("Operation Cancelled");
            return null;
        }

        #region Unfinished API
        public async static Task<StorageFile> PickFiles(List<string> fileTypes,
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
                return file;
            }

            Console.WriteLine("Operation cancelled.");
            return null;
        }
        #endregion
    }
}

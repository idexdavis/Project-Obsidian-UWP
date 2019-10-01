using System.Collections.ObjectModel;
using Project_Obsidian_UWP.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Project_Obsidian_UWP.ViewModels
{
    public class WorkspaceDetailViewModel: ReactiveObject
    {
        [Reactive]
        public Category category { get; set; }

        [Reactive]
        public ObservableCollection<Post> posts { get; set; }


    }
}

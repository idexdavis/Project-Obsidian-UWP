using Project_Obsidian_UWP.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Obsidian_UWP.ViewModels
{
    public class WorkspaceViewModel: ReactiveObject
    {
        [Reactive]
        public ObservableCollection<Category> categories { get; set; }

        [Reactive]
        public ObservableCollection<Page> pages { get; set; }
    }
}

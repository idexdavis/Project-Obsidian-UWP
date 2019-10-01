using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Project_Obsidian_UWP.Core;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Project_Obsidian_UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WorkspacePage : Page
    {
        public ViewModels.WorkspaceViewModel ViewModel { get; set; }

        public WorkspacePage()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) =>
            {
                ViewModel = DataContext as ViewModels.WorkspaceViewModel;
            };
        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {
            ViewModel.categories = Core.Core.categoryManager.GetCategoriesCollection();
            ViewModel.pages = Core.Core.pageManager.GetPagesCollection();

            bool isValid = await DefineLocation.LocateAndCheckRepo();
        }

        private async void CategoryListView_Loading(FrameworkElement sender, object args)
        {
            while (Core.Core.rootFolder == null)
            {
                await Task.Delay(25);
            }
            await Loader.ReadAllCategories(Core.Core.rootFolder);
        }

        private void CategoryListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCategory = CategoryListView.SelectedItem;
            DetailFrame.Navigate(typeof(WorkspaceDetailPage), selectedCategory);
        }
    }
}

using Project_Obsidian_UWP.Models;
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Project_Obsidian_UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WorkspaceDetailPage : Windows.UI.Xaml.Controls.Page
    {
        public delegate void MainNaviDelegate(object source, EventArgs e);
        public static event MainNaviDelegate OnNavigateMainReady;
        public ViewModels.WorkspaceDetailViewModel ViewModel { get; set; }

        public WorkspaceDetailPage()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) =>
            {
                ViewModel = DataContext as ViewModels.WorkspaceDetailViewModel;
            };
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            while (ViewModel == null)
            {
                await Task.Delay(25);
            }

            ViewModel.category = e.Parameter as Category;
            ViewModel.posts = ViewModel.category.posts.GetPosts();
        }

        private void PostsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OnNavigateMainReady(sender, null);
        }
    }
}

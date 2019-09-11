﻿using Project_Obsidian_UWP.Views;
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
using Project_Obsidian_UWP.Utilities;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Project_Obsidian_UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void MainNaviView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            FrameNavigationOptions navOptions = new FrameNavigationOptions();
            navOptions.TransitionInfoOverride = args.RecommendedNavigationTransitionInfo;
            
            Type pageType;
            NavigationViewItem naviItem = sender.SelectedItem as NavigationViewItem;

            if (args.IsSettingsInvoked)
            {
                pageType = typeof(SettingsPage);
            }
            else
            {
                switch (naviItem.Tag as string)
                {
                    case "Workspace":
                        pageType = typeof(WorkspacePage);
                        break;

                    default:
                        Console.WriteLine("No match navi item.");
                        return;
                }
            }

            MainFrame.NavigateToType(pageType, null, navOptions);
        }
    }
}

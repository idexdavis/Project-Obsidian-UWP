using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Obsidian_UWP.Utilities
{
    public class Constants
    {
        #region Constants for checking validality of user selection.
        public const string configUrl = @"https://github.com/idexdavis/idex-blog.git";
        public const string configOrg = @"idex";
        public const string configVersion = @"1.0";
        #endregion

        #region Constants for file or folder path
        public const string categoriesPath = @"_featured_categories";
        public const string postsPath = @"posts";
        public const string assetsPath = @"assets";
        public const string configFilePath = @"_config.yml";
        public const string notFoundPagePath = @"404.html";
        public const string aboutPagePath = @"about.md";
        #endregion

        public const bool allowRefreshByMenuItem = false;
    }
}

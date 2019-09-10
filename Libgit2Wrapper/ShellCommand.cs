using LibGit2Sharp;
using System.Runtime.InteropServices;

namespace Libgit2Wrapper
{
    public class ShellCommand
    {
        public static string ExeCommand()
        {
            string directory = @"C:\Users\yanyi\Documents\GitHub\"; // directory of the git repository

            Repository.Clone("https://github.com/totoroyyb/About-SwiftUI.git", @"C:\Users\yanyi\Downloads");

            return directory;

            //using (PowerShell powershell = PowerShell.Create())
            //{
            //    // this changes from the user folder that PowerShell starts up with to your git repository
            //    powershell.AddScript(String.Format(@"cd {0}", directory));

            //    powershell.AddScript(@"git init");
            //    powershell.AddScript(@"git add *");
            //    powershell.AddScript(@"git commit -m 'git commit from PowerShell in C#'");
            //    powershell.AddScript(@"git push");

            //    Collection<PSObject> results = powershell.Invoke();
            //}

            //Console.WriteLine(directory);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Collections.ObjectModel;

namespace Project_Obsidian_UWP.Core
{
    public class ShellCommand
    {
        public static void ExeCommand()
        {
            string directory = @"C:\Users\yanyi\Documents\GitHub\"; // directory of the git repository

            using (PowerShell powershell = PowerShell.Create())
            {
                // this changes from the user folder that PowerShell starts up with to your git repository
                powershell.AddScript(String.Format(@"cd {0}", directory));

                powershell.AddScript(@"git init");
                powershell.AddScript(@"git add *");
                powershell.AddScript(@"git commit -m 'git commit from PowerShell in C#'");
                powershell.AddScript(@"git push");

                Collection<PSObject> results = powershell.Invoke();
            }
        }
    }
}

using BankAccountManager.Core;
using System;
using System.Windows.Forms;

namespace BankAccountManager
{
    static class StartUp
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login(new Engine()));
            //Application.Run(new Engine());
            //System.Diagnostics.Process.Start(@"cmd.exe", @"/k D:\Programming\University\Coursework\BankAccountManager");
        }
    }
}

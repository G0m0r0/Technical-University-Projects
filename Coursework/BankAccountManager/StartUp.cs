using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Application.Run(new Login());
            //System.Diagnostics.Process.Start(@"cmd.exe", @"/k D:\Programming\University\Coursework\BankAccountManager");
        }
    }
}

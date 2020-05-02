using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace fn181218001
{
    public class test
    {
        Process proc = new Process();
     
        public void testt()
        {
            proc.StandardInput.WriteLine("p1.exe -h");
            var a = proc.StandardOutput.ReadLine();

            int count = 0;
            while (true)
            {
                if (a != string.Empty)
                {
                    count++;
                }
                if (count == 3)
                {
                    break;
                }

            }
        }
    }
}

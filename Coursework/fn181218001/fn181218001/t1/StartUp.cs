﻿namespace t1
{
    using System;
    using System.Diagnostics;

    class StartUp
    {
        static void Main(string[] args)
        {
            string path = 
                @"D:\Programming\University\Coursework\fn181218001\fn181218001\p1\bin\Debug\netcoreapp3.1\p1.exe";
            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = false;
            proc.StartInfo.UseShellExecute = false;
            proc.Start();

            proc.StandardInput.WriteLine($"{path} -h");

            proc.StandardInput.WriteLine($"{path} -g un.txt");

            proc.StandardInput.WriteLine($"{path} -v un.txt");

            proc.StandardInput.WriteLine($"{path} -s un.txt st.txt");

            proc.StandardInput.WriteLine($"{path} -v test2.txt");

            proc.StandardInput.WriteLine($"{path} -e");

            proc.StandardInput.Flush();
            proc.StandardInput.Close();
            proc.WaitForExit();
            Console.WriteLine(proc.StandardOutput.ReadToEnd());
        }
    }
}

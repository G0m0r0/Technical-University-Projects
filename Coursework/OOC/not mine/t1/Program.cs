using System;
using System.Diagnostics;


namespace t1
{
    class Program
    {
        static void Main(string[] args)
        {

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = false;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();


            cmd.StandardInput.WriteLine("cd ../../../..");
            cmd.StandardInput.WriteLine("cd p1/bin/Debug/netcoreapp3.0");
            cmd.StandardInput.WriteLine("p1.exe -h");
            
            cmd.StandardInput.WriteLine("p1.exe -g NumFile.txt");
            
            cmd.StandardInput.WriteLine("p1.exe -v NumFile.txt");
            
            cmd.StandardInput.WriteLine("p1.exe -s NumFile.txt NumFileSorted.txt");
            
            cmd.StandardInput.WriteLine("p1.exe -v NumFileSorted.txt");
           
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());

            

        }
    }
}

namespace t1
{
    using System;
    using System.Diagnostics;

    class StartUp
    {
        static void Main()
        {
            string path = 
                @"D:\Programming\University\Coursework\fn181218001\fn181218001\p1\bin\Debug\netcoreapp3.1\p1.exe";

            string output;
            using (Process myProcess = new Process())
            {
                myProcess.StartInfo.FileName = "cmd.exe";
                myProcess.StartInfo.RedirectStandardInput = true;
                myProcess.StartInfo.RedirectStandardOutput = true;
                myProcess.StartInfo.CreateNoWindow = false;
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.Start();

                TestAllCommands(myProcess, path);

                myProcess.StandardInput.Close();
                myProcess.WaitForExit();
                output= myProcess.StandardOutput.ReadToEnd();
            }

            Console.WriteLine(output);
        }

        private static void TestAllCommands(Process myProcess, string path)
        {
            myProcess.StandardInput.WriteLine($"{path} -h");

            myProcess.StandardInput.WriteLine($"{path} -g un.txt");

            myProcess.StandardInput.WriteLine($"{path} -v un.txt");

            myProcess.StandardInput.WriteLine($"{path} -s un.txt st.txt");

            myProcess.StandardInput.WriteLine($"{path} -v test2.txt");

            myProcess.StandardInput.WriteLine($"{path} -e");
        }
    }
}

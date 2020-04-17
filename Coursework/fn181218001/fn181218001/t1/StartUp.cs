namespace t1
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            // Diagnostics.Process.Start
            // args = Console.ReadLine().Split(" ");
            //D:\Programming\University\Coursework\fn181218001\fn181218001\p1\bin\Debug\netcoreapp3.1\p1.exe

            //System.Diagnostics.Process.Start(args[0]);

            System.Diagnostics.Process.Start(@"D:\Programming\University\Coursework\fn181218001\fn181218001\p1\bin\Debug\netcoreapp3.1\p1.exe");

            Console.WriteLine("-h");
        }
    }
}

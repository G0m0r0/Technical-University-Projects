using System;
using System.IO;

namespace testtttt
{
    class Program
    {
        static void Main()
        {
            string path = Console.ReadLine();
            using (StreamReader writer = File.Open(path,FileMode create))
            {
                for (int i = 2500; i <= 4006; i++)
                {
                  //  if (i == 100) Console.WriteLine();
                    writer.Write(i + " ");
                }
             } 
        }
    }
}

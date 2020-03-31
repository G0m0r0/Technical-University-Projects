using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; /// <summary>
/// 
/// </summary>


namespace files_read_write
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("storage.txt"))
            {
                string stored = File.ReadAllText("storage.txt");
                Console.WriteLine(stored);
            }
                string s = Console.ReadLine();
                File.WriteAllText("storage.txt", s);
        }
    }
}

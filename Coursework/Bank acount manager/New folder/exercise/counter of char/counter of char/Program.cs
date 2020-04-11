using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace counter_of_char
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Write path to file: ");
            string path = Console.ReadLine();
            string extension = Path.GetExtension(path);
            string filname = Path.GetFileName(path);
            string filnaNoExtension = Path.GetFileNameWithoutExtension(path);
            string root = Path.GetPathRoot(path);
            Console.WriteLine("{0}\n{1}\n{2}\n{3}",
                extension,
                filname,
                filnaNoExtension,
                root);
        }
    }
}

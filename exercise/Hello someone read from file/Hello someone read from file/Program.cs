using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hello_someone_read_from_file
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "date.dat";
            string name;
            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    name = reader.ReadToEnd();
                }
            }
            else
            {
                using (StreamWriter write = new StreamWriter(fileName))
                {
                    Console.Write("Your name ");
                    name = Console.ReadLine();
                    write.Write(name);
                }
            }
            Console.WriteLine("Hello, {0}",name);
        }
    }
}

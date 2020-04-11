using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace read_write_sting
{
    class Program
    {
        static void Main(string[] args)
        {
            string filName = "date.txt";
            using (StreamWriter writer = new StreamWriter(filName, false)) 
            {
                for (int i = 0; i < 100; i++)
                {
                    writer.Write(i);
                }
            }
            using (StreamReader reader = new StreamReader(filName))
            {
                char[] cache;
                while (reader.Peek() >= 0)
                {
                     cache = new char[10];
                    reader.Read(cache, 0, 10);
                    Console.WriteLine(cache);
                }
                
            }
        }
    }
}

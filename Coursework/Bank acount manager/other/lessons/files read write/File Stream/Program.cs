using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace File_Stream
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = File.Open("storage.txt", FileMode.OpenOrCreate); //open or create file
            var rng = new Random();
            for (int i = 0; i < 100000; ++i)
            {
                string line = rng.Next() + Environment.NewLine;
                byte[] lineBytes = Encoding.UTF8.GetBytes(line);
                f.Write(lineBytes, 0, lineBytes.Length);
            }
            f.Close(); //close the file !!!Important!!!
        }
    }
}

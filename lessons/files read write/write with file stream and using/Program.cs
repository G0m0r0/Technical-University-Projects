using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace write_with_file_stream_and_using
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var f = File.Open("storage.txt", FileMode.Create))
            {
                var rng = new Random();
                for (int i = 0; i < 5; ++i)
                {
                    string line = rng.Next() + Environment.NewLine;
                    byte[] lineBytes = Encoding.UTF8.GetBytes(line);
                    f.Write(lineBytes, 0, lineBytes.Length);
                }
            } //   automaticly close no need of f.close();   
              //create a file with five integers inside
        }
    }
}

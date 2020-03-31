using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Write_and_read_stream_Reader
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
            var entropy = new int[5];
            using (var f = File.OpenText("storage.txt"))
            {
                int lineNum = 0; while (!f.EndOfStream)
                {
                    string line = f.ReadLine();
                    entropy[lineNum++] = int.Parse(line);
                }
            }
            foreach (var num in entropy)
                Console.WriteLine(num);


        }
    }
}

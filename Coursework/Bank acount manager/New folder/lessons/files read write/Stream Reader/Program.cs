using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Stream_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            var entropy = new int[100000];
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

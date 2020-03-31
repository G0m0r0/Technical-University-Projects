using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string myText = "Hello, how are you ?, Are you okay";
            string[] names = myText.Split(' ');
            foreach(string x in names)
            {
                Console.WriteLine(x);
            }
        }
    }
}

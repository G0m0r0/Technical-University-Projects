using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @foreach
{
    class Program
    {
        static void Main(string[] args)
        {
                string input = Console.ReadLine();
                foreach (var ch in input) //we declare ch as variable
                    Console.WriteLine("Code of the letter '{0}' is {1}", ch,(int)ch);
        }
    }
}

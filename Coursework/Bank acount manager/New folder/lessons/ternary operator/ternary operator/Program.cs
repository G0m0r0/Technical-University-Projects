using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ternary_operator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Check if the two integer are equal:");
            Console.Write("Enter A= ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter B= ");
            int b = int.Parse(Console.ReadLine());
            string c = string.Empty;
            Console.WriteLine((a == b) ? "Numbers are equal!" : "Numbers are not equal! ");

        }
    }
}

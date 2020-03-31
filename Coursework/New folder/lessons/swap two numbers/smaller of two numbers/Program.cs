using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smaller_of_two_numbers
{
    class Program
    {
        public static int Min(int a, int b)
        {
            return a < b ? a : b;
        }
        static void Main()
        {
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int m = Min(c,d); // Извикване на ф-я с аргументи c и d	
            Console.WriteLine("Smaller number is {0}", m);
        }
    }
}

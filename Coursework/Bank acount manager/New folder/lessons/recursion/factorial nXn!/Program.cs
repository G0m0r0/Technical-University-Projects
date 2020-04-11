using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace factorial_nXn_
{
    class Program
    {
        static int Factorial(int x)
        {
            int resultPrev=1;
            if (x == 1) return 1;
            else
            {
                resultPrev = Factorial(x - 1);
                Console.WriteLine($"{x}.{resultPrev}");
                return x * resultPrev;

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number:");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine(Factorial(x));
        }
    }
}

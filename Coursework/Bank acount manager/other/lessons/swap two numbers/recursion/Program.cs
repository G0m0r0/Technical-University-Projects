using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recursion
{
    class Program
    {
        static ulong Factorial(uint n)
        {
            if (n <= 1) // Краен случай		
            return 1;
            //Console.WriteLine(n);
            return n*Factorial(n-1); // Рекурсивен случай
        }
        static void Main(string[] args)
        {
            uint a = uint.Parse(Console.ReadLine());
            ulong fn = Factorial(a);
            //Console.WriteLine(fn);
            //Console.WriteLine(a);
            Console.WriteLine("{0}! = {1}", a, fn);
        }
    }
}

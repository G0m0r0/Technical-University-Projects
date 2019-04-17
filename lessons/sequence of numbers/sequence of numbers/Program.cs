using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sequence_of_numbers
{
    class Program
    {
        static uint inter(uint n)
        {
            if (n <= 3) return (uint)n * 2;
            uint ai = 0;
            uint a = 2, //ai3
                b = 4, //ai2
                c = 6; //ai1
            for (int i = 4; i <= n; i++)
            {
                ai = 3 * a + 4 * b - 7 * c;
                a = b;
                b = c;
                c = ai;
            }
            return ai;
        }
        static uint recursive(int n)
        {
           // uint ai = 0;
            if (n <= 3) return 2 * (uint)n;
            return 3 * recursive(n - 3) + 4 * recursive(n - 2) - 7 * recursive(n - 1);
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();
      

        }
    }
}

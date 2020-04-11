using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2.NestedLoopsToRecursion
{
    class NestedLoopsToRecursion
    {
        static int n;
        static int n1;
        static int[] array;

        static void NestedLoops(int x)
        {
            if (x == n)
            {
                PrintLoops();
                return;
            }
            for (int i = 1; i <= n1; i++)
            {
                array[x] = i;
                NestedLoops(x + 1);
            }
        }

        static void PrintLoops()
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", array[i]);
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            n1 = n;
            array = new int[n];
            NestedLoops(0);

        }
    }
}
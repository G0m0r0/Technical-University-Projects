using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nested_loops_to_recursion
{
    class Program
    {

        static void nesttedRucursion(int x)
        {
            

        }
        static void printNum(int x)
        {
            for (int i = 1; i < x; i++)
            {
                Console.Write(i);
            }
        }
        static void Main(string[] args)
        {
           int n = int.Parse(Console.ReadLine());
           nesttedRucursion(n);
        }
    }
}

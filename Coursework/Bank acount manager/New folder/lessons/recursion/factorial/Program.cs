using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace factorial
{
    class Program
    {
        static int recursionSequence(int n)
        {
            if (n == 1) return 2;
            if (n == 2) return 4;
            if (n == 3) return 6;
            int[] array = new int[3];

        }
        static void Main(string[] args)
        {
            Console.Write("Enter searched number in the sequence: ");
            int n = int.Parse(Console.ReadLine());
            //int[] array = new int[3];
            Console.WriteLine("Searched number at place {0} is {1}.",n, recursionSequence(n,)); 
        }
    }
}

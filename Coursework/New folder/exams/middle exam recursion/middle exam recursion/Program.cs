using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace middle_exam_recursion
{
    class Program
    {
        static int recSequ(int n)
        {
            if (n == 1) return -1;
            else if (n == 2) return 2;
            else if (n == 3) return 3;
            return recSequ(n - 1) + recSequ(n - 2) + recSequ(n - 3);
        }
        static void Main(string[] args)
        {
            Console.Write("Enter N= ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(recSequ(n));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_swap
{
    class Program
    {
        static void swapNum(ref int a,ref int b)
        {
            a += b;
            b = a - b;
            a -= b;
        }
        static void Main(string[] args)
        {
            Console.Write("A= ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("B= ");
            int b = int.Parse(Console.ReadLine());
            swapNum(ref a, ref b);
            Console.WriteLine("A= {0} B={1}",a,b);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_triangle
{
    class Program
    {
        static void PrintNum(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= num; i++)
            {
                PrintNum(1, i);
            }
            for (int i = num - 1; i >= 1; i--)
            {
                PrintNum(1, i);
            }

           // for (int i = 1; i <= num; i++)
           // {
           //     for (int j = 1; j <= i; j++)
           //     {
           //         Console.Write(j + " ");
           //     }
           //     Console.WriteLine();
           // }
           // for (int i = num - 1; i > 0; i--)
           // {
           //     for (int j = 1; j <= i; j++)
           //     {
           //         Console.Write(j + " ");
           //     }
           //     Console.WriteLine();
           // }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void FillMatrix(int[,] a)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write("Element {0}{1} = ", i,j);
                    a[i, j] = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                }
            }
        }
        static void Main(string[] args)
        {
            //how to fill matrix with method
            int[,] a = new int[2,2];
            FillMatrix(a);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.WriteLine(a[i, j] + " ");
                }
                
            }
        }
    }
}

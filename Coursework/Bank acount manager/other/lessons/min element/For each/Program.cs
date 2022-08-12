using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For_each
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = { { 1, 2, 3 }, { 2, 3, 4 }, { 3, 4, 5 } };
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Console.WriteLine($"Position ({i},{j})={arr[i, j]}");
            Console.Read();
        }
    }
}

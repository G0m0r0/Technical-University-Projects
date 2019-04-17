using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reversed_array
{
    class Program
    {
        // static void fillArray(int[] array,int n)
        // {
        //     for (int i = 0; i < n; i++)
        //     {
        //         array[i] = int.Parse(Console.ReadLine());
        //     }
        // }
        static void recursionArray(int[] array, int n)
        {
            if (n == 0)
            {
                Console.Write(array[n] + " ");
                return;
            }
            else
            {
                Console.Write(array[n] + " ");
                recursionArray(array, n - 1);
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter lenght of array= ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter elements of array:");
            int[] array = new int[n];
            //fillArray(array, n);
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            recursionArray(array, n-1);
        }
    }
}

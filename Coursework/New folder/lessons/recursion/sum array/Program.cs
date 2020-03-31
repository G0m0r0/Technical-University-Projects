using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sum_array
{
    class Program
    {
        static int sum = 0;
        static int sumArray(int[] array,int n)
        {
            sum += array[n];
            if (n == 0) return sum;
            else return sumArray(array, n - 1);
        }
        static void fillArray(int[] array,int n)
        {
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter number of elements=");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Fill elements of the array:");
            int[] array = new int[n];
            fillArray(array,n);
                Console.WriteLine("Sum of elements is= {0}",sumArray(array,n-1));
        }
    }
}

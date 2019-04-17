using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liner_searching_in_mass
{
    class Program
    {
       public static int FindIndex(int[] arr, int val)
        {
            for (int i = 0; i < arr.Length; ++i)
                if (arr[i] == val)
                    return i;
            return -1;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int searchInt = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = i;
            }
            Console.WriteLine(FindIndex(a,searchInt));
            
        }
    }
}

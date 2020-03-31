using System;
using System.Linq;

namespace rotate_array_on_given_pivot
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rightPivot = int.Parse(Console.ReadLine());

            for (int i = 1; i <= rightPivot; i++)
            {
                int temp = array[0];
                for (int j = 1; j < array.Length; j++)
                    array[j - 1] = array[j];
                array[array.Length - 1] = temp;
            }
            Console.WriteLine(string.Join(" ",array));
        }
        static void Swap(ref int a,ref int b)
        {
            int swap = a;
            a = b;
            b = swap;
        }
    }
}

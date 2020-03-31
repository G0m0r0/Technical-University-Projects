using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selection_sort
{
    class Program
    {
        static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; ++i)
            {
                int min = i;
                for (int k = i + 1; k < array.Length; ++k)
                    if (array[k] < array[min])
                        min = k;
                if (min != i)
                { // Трябва размяна
                    swapValue(ref array[min],ref array[i]);
                }
            }
        }
        static void swapValue(ref int a,ref int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
        static void InputArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Element {0} = ", i + 1);
                array[i] = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
        }
        static void OutputArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]+" ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter array lenght");
            int n=int.Parse(Console.ReadLine());
            int[] array = new int[n];
            Console.WriteLine("Fill array:");
            InputArray(array);
            Console.WriteLine("Array sorted");
            SelectionSort(array);
            Console.WriteLine("Sorted array:");
            OutputArray(array);
        }
    }
}

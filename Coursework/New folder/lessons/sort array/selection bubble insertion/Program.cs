using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selection_bubble_insertion
{
    class Program
    {
        // performs poorly on any but the smallest collections.
        static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; ++i)
            {
                int min = i;
                for (int k = i + 1; k < array.Length; ++k)
                    if (array[k] < array[min])
                        min = k;
                if (min != i)
                { 
                    swapValues(ref array[min], ref array[i]);
                }
            }
        }
       //when you are teaching someone about sorting
        static void BubbleSort(int[] array)
        {
            bool sorted;
            do
            {
                sorted = true;
                for (int i = 1; i < array.Length; ++i)
                    if (array[i] < array[i - 1])
                    {
                        sorted = false;
                        swapValues(ref array[i], ref array[i - 1]);
                    }
            } while (!sorted);
        }
        // Inserstion Sort - good on nearly sorted or very small collection
        void InsertionSort(decimal[] array)
        {
            for (int i = 1; i < array.Length; ++i)
            {
                decimal value = array[i];
                int hole = i;
                while (hole > 0 && array[hole - 1] >= value)
                {
                    array[hole] = array[hole - 1]; // местим елем. надясно			
                    --hole;
                }
                array[hole] = value;
            }
        }

        static void swapValues(ref int a, ref int b)
        {
            a *= b;
            b = a / b;
            a /= b;
        }
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());

            int b = int.Parse(Console.ReadLine());

            swapValues(ref a, ref b);
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}

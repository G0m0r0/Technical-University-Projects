using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selection_incertion_bubble_sort
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
                    swapValue(ref array[min], ref array[i]);
                }
            }
        }
        static void Main(string[] args)
        {
        }
    }
}

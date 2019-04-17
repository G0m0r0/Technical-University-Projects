using System;

namespace sort_array
{
    class Program
    {
        static void BubbleSort(decimal[] array)
        {
            bool sorted;
            do
            {
                sorted = false;
                for (int i = 1; i < array.Length; ++i)
                if (array[i] < array[i - 1])
                {
                        sorted = true;
                   swapValues(ref array[i], ref array[i - 1]);     
                }
            } while (sorted);
        }
        static void FillArray(decimal[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Element {0} =",i+1 );
                array[i] = decimal.Parse(Console.ReadLine());
                //Console.WriteLine();
            }
        }
        static void swapValues(ref decimal a,ref decimal b)
        {
            var temp = b;
            b = a;
            a = temp;
        }
        static void PrintArray(decimal[] arrray)
        {
            for (int i = 0; i < arrray.Length; i++)
            {
                Console.Write(arrray[i]+" ");
            }
        }
        static void Main()
        {
            Console.WriteLine("Enter size of array");
            int n = int.Parse(Console.ReadLine());

            decimal[] array = new decimal[n];
            Console.WriteLine("Fill array");
            FillArray(array);

            BubbleSort(array);
            Console.WriteLine();
            PrintArray(array);
        }
    }
}

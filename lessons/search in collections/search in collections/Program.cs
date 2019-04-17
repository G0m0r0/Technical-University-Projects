using System;

namespace search_in_collections
{
    class Program
    {
        static bool LinearSearch(decimal[] array, decimal value, out int position)
        {
            for (int i = 0; i < array.Length; ++i)
                if (array[i] == value)
                {
                    // Елементът е намерен?			
                    position = i;
                    return true;
                }   
            // Елементът не е намерен	
            position = -1;
            return false;
        }
        static void FillArray(decimal[] array,int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("Element {0} = ",i+1);
                array[i] = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter lengh of array");
            int n = int.Parse(Console.ReadLine());
            decimal[] array = new decimal[n];
            int possition = 0;
            Console.WriteLine("Enter searched element");
            decimal searchedNum = decimal.Parse(Console.ReadLine());
            FillArray(array,n);
            if (LinearSearch(array,searchedNum ,out possition)) Console.WriteLine("Searched element is on possition {0}.",possition+1);
            else Console.WriteLine("There is no element like this!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace min_element
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of elements= ");
            int numElements = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[numElements];
            for (int i = 0; i < numElements; i++)
            {
                Console.Write($"Enter element {i + 1}: ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
           // int min = arr[0];
            int min = int.MaxValue;
            int minIndex = 0;
            for (int i = 0; i < numElements; i++)
            {
                if (min > arr[i])
                {
                    min = arr[i];
                    minIndex = i;

                }    
                    
            }
            Console.WriteLine("Smallest number is " + min + " and it index is " + minIndex);
            Console.Read();
            for (int i = 0; i < numElements; i++)
            {
               
                if (min == arr[i])
                {
                    Console.WriteLine("Index", i);

                }
            }
        }
    }
}

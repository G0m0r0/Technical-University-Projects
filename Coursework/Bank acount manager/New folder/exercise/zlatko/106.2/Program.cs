using System;
using System.Linq;

namespace _106._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //sequence S page 106 exercise 2
            Console.Write("Enter number of elements: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter sum number: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Enter sequence of numbers. Joined by space: ");
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            if(IsXequalsSumOfTwoNumbers(array,x))
            {
                Console.WriteLine($"There is two numbers which sum equals {x}");
            }
            else
            {
                Console.WriteLine($"There is no elements which sum equals {x}");
            }
        }

        private static bool IsXequalsSumOfTwoNumbers(int[] array, int x)
        {
            int leftIndex = 0;
            int rightIndex = array.Length - 1;
            for (int i = 0; i < array.Length; i++)
            {
                if(array[leftIndex]+array[rightIndex]>x)
                {  
                    rightIndex--;
                }
                else if(array[leftIndex]+array[rightIndex]<x)
                {
                    leftIndex++;
                }
                else if(leftIndex!=rightIndex)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

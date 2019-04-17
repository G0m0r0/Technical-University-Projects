using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort_array
{
    class Program
    {
        static void BubbleSort(decimal[] array)
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
        static void FillArray(decimal[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Element {0} =", i + 1);
                array[i] = decimal.Parse(Console.ReadLine());
                //Console.WriteLine();
            }
        }
        static void swapValues(ref decimal a, ref decimal b)
        {
            var temp = b;
            b = a;
            a = temp;
        }
        static void PrintArray(decimal[] arrray)
        {
            for (int i = 0; i < arrray.Length; i++)
            {
                Console.Write(arrray[i] + " ");
            }
        }
        static bool BinarySearch(decimal[] a, decimal searchedValue, out int position)
        {
            int start = 0;
            int end = a.Length;
            while (start < end)
            {
                int mid = start + (end - start) / 2;
                if (a[mid] == searchedValue)
                {
                    position = mid;
                    return true;
                }
                else if (a[mid] > searchedValue) end = mid - 1;
                else start = mid + 1;
            }
            position = -1; //we must to have position if we use out
            return false;
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Create and enter size of array");
                Console.Write("Size= ");
                int n = int.Parse(Console.ReadLine());
                decimal[] array = new decimal[n];
                Console.WriteLine("Operate with Array:");

                int choice = 0;
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("1 - Input array " +
                   "2 - Bubble Sort array " +
                   "3 - show sort array " +
                   "4 - Find number ");
                    Console.WriteLine("Other numbers to exit");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.WriteLine("Fill array");
                                FillArray(array);
                            }
                            break;
                        case 2:
                            {
                                Console.WriteLine("Array is sorted!");
                                BubbleSort(array);
                            }
                            break;
                        case 3:
                            {
                                Console.WriteLine("Your array");
                                PrintArray(array);
                            }
                            break;
                        case 4:
                            {
                                Console.Write("Search= ");
                                decimal searchValue = decimal.Parse(Console.ReadLine());
                                int position;
                                if (BinarySearch(array, searchValue, out position)) Console.WriteLine("Your value is in the array on position {0}", position + 1);
                                else Console.WriteLine("Searched value {0} is not in the array!", searchValue);
                            }
                            break;
                        default: Console.WriteLine("Closing program..."); break;
                    }
                } while (choice == 1 || choice == 2 || choice == 3 || choice == 4);
            }
            catch
            {
                Console.WriteLine("Error!");
            }
            finally
            {
                Console.WriteLine("Program executed successfuly!");
            }
        }
    }
}
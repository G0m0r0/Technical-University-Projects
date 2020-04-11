﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_search
{
    class Program
    {
     static int BinarySearch(decimal[] a,decimal searchedValue,out int position)
        {
            int start = 0;
            int end = a.Length;
            while(start<=end)
            {
                int mid = start + (end - start) / 2;
                if (a[mid] == searchedValue)
                {
                    position = mid;
                    return mid;
                }
                else if (a[mid] > searchedValue) end = mid - 1;
                else start = mid + 1;
            }
            position = -1;
            return -1;
        }

        static void FillArray(decimal[] array, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("Element {0} = ", i+1);
                array[i] = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Enter lengh of array");
            int n = int.Parse(Console.ReadLine());

            decimal[] array = new decimal[n];

            int position;

            Console.WriteLine("Enter searched element");
            decimal searchedNum = decimal.Parse(Console.ReadLine());

            FillArray(array, n);
            if(BinarySearch(array, searchedNum,out position)!=-1) Console.WriteLine("Searched element is on possition {0}.", position + 1);
            else Console.WriteLine("There is no element like this!");
        }
    }
}

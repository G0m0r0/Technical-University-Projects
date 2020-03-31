using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix_line_search
{
    class Program
    {
        static int FindIndex(int[] arr, int val)
        {
            for (int i = 0; i < arr.Length; ++i)
                if (arr[i] == val)
                    return arr[i]; 
                return -1;
        }
        static void InputMass(int [] arr,int val)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter N= ");
            int n = int.Parse(Console.ReadLine());
            int[] mass = new int[n];
            Console.WriteLine("Enter the mass");
            InputMass(mass, n);
            int searchedNum = FindIndex( mass, n);
            if(searchedNum!=-1)Console.WriteLine("Searched number {0} is the mass. ",searchedNum);
            else Console.WriteLine("Searched number is not int the mass!");
        }
    }
}

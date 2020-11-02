using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] array = { 2, 2, 2, 0, 0, 0, 1, 1 };
            DutchNationalFlag(array);

            Console.WriteLine(string.Join(" ", array));
        }

        static void Swap(int[] array, int x, int y)
        {
            int temp = array[x];
            array[x] = array[y];
            array[y] = temp;
        }

        static void DutchNationalFlag(int[] array)
        {
            int low = 0;
            int high = array.Length - 1;
            for (int i = 0; i <= high; i++)
            {
                if (array[i] == 0)
                    Swap(array, low++, i--);

                if (array[i] == 2)
                    Swap(array, i--, high--);
            }
        }
    }
}

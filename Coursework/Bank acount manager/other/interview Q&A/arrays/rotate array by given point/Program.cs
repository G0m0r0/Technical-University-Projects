using System;
using System.Linq;

namespace rotate_array_by_given_point
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 2 3 - 4 5 --2
            //4 5 1 2 3
            int[] numbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int index = int.Parse(Console.ReadLine());

            int[] leftNumbers = new int[index+1];
            int[] rightNumbers = new int[numbers.Length - index-1];
            for (int i = 0; i < leftNumbers.Length; i++)
            {
                leftNumbers[i] = numbers[i];
            }
            int counter = 0;
            for (int i = leftNumbers.Length; i <numbers.Length ; i++)
            {
                rightNumbers[counter] = numbers[i];
                counter++;
            }
            Console.WriteLine(string.Join(" ",rightNumbers)+" "+string.Join(" ",leftNumbers));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

//page 94 exercise 6
//2D array with apples
namespace _94._6
{
    class Program
    {
        //not finished
        static int[,] apples;
        static List<char> paths;
        static StringBuilder path=new StringBuilder();
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter M: ");
            int m = int.Parse(Console.ReadLine());
            apples = new int[n, m];

            InitializeCountOfApples(apples);

            PrintApples(apples);

            FindAllCombinations(0, 0, ' ');
        }
        private static void FindAllCombinations(int x, int y, char direction)
        {
            
        }

        private static bool OutSide(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return true;
            }
            if (x>apples.GetLength(0)||y>apples.GetLength(1))
            {
                return true;
            }
            return false;
        }


        private static void PrintApples(int[,] apples)
        {
            for (int i = 0; i < apples.GetLength(0); i++)
            {
                for (int j = 0; j < apples.GetLength(1); j++)
                {
                    if (apples[i, j] < 10)
                        Console.Write($"{apples[i, j]}  ");
                    else
                        Console.Write($"{apples[i,j]} ");
                }
                Console.WriteLine();
            }
        }

        private static void InitializeCountOfApples(int[,] apples)
        {
            for (int i = 0; i < apples.GetLength(0); i++)
            {
                for (int j = 0; j < apples.GetLength(1); j++)
                {
                    Random rnd = new Random();
                    int number = rnd.Next(0, 100);
                    apples[i, j] = number;
                }
            }
        }
    }
}

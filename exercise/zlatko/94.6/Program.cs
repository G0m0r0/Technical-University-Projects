using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//page 94 exercise 6
//2D array with apples
namespace _94._6
{
    class Program
    {
        static int[,] apples;
        static Dictionary<string,int> paths=new Dictionary<string, int>();
        static int value;
        static List<char> path = new List<char>();
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

            Console.WriteLine("All paths ordered by total sum:");
            foreach (var kvp in paths.OrderByDescending(x=>x.Value))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
        private static void FindAllCombinations(int x, int y, char direction)
        {
            if (OutSide(x, y))
            {
                return;
            }

            value += apples[x, y];
            path.Add(direction);

            if (x==apples.GetLength(0)-1&&y==apples.GetLength(1)-1)
            {
                //add to dictionary
                paths.Add(string.Join("",path), value);
            }

            FindAllCombinations(x + 1, y, 'D'); //Down
            FindAllCombinations(x, y + 1, 'R'); //Right

            path.RemoveAt(path.Count - 1);
            value -= apples[x, y];
        }

        private static bool OutSide(int x, int y)
        {
                if (x < 0 || x >= apples.GetLength(0))
                {
                    return true;
                }

                if (y < 0 || y >= apples.GetLength(1))
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

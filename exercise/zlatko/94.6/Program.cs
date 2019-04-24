using System;

//page 94 exercise 6
//2D array with apples
//not finished
namespace _94._6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter M: ");
            int m = int.Parse(Console.ReadLine());
            int[,] apples = new int[n, m];

            InitializeCountOfApples(apples);

            PrintApples(apples);


        }

        private static void PrintApples(int[,] apples)
        {
            throw new NotImplementedException();
        }

        private static void InitializeCountOfApples(int[,] apples)
        {
            throw new NotImplementedException();
        }
    }
}

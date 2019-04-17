using System;

namespace matrix
{
    class Program
    {
       static decimal MaxOnMainDiagonal(decimal[,] matrix)
        {
            if (matrix != null)
            {
                decimal max = matrix[0,0];
                for (int i = 1; i < matrix.GetLength(0); ++i)
                    if (matrix[i, i] > max) max = matrix[i, i];
                return max;
            }     // matrix е null – да изведем грешка? Ами ако не е конзолно?	
            Console.WriteLine("Не е подадена матрица");
            return 0;
        } //ERROR: Not all code paths return a value
    static void ReadMatrix(decimal[,] matrix,int n)
        {   
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Element{i}{j}= ");
                    matrix[i,j] = decimal.Parse(Console.ReadLine());
                }
            }
        }
        static void Main()
        {
            try
            {
                Console.WriteLine("Enter size of the matrix");
                int n = int.Parse(Console.ReadLine());
                decimal[,] matrix = new decimal[n, n];
                int choice = 0;
                do
                {
                    Console.WriteLine("Menu: 1 - enter matrix; 2 - max on main diagonal 0 - End program");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1: ReadMatrix(matrix, n); break;
                        case 2:
                            {
                                try
                                {
                                    Console.WriteLine("Max on main diagonal is {0}", MaxOnMainDiagonal(matrix));                  // Ами ако matrix e null?
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Error! " + e);
                                }
                            }
                            break;
                    }
                } while (choice != 0);
            }
            catch //(Exception e)
            {
                Console.WriteLine("Error!!!");
               // Console.WriteLine(e);
            }
        }

    }
}

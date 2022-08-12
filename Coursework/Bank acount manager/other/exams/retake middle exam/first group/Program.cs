using System;

namespace first_group
{
    class Program
    {
        static decimal sumNegativeOnOdd(decimal[,] mat)
        {
            decimal sumNegative = 0;
            for (int i = 0; i < mat.GetLength(1); i++)
            {
                for (int j = 0; j < mat.GetLength(0); j++)
                {
                    if (mat[i, j] < 0)
                        if (i%2!=0&&j%2!=0)
                        {
                           sumNegative += mat[i, j];
                        }
                }
            }
            return sumNegative;
        }
        static decimal CountEvenOnAntiDiagonal(decimal[,] mat)
        {
            int count = 0;
            for (int i = 0; i < mat.GetLength(1); i++)
            {
                for (int j = mat.GetLength(1) - 1; j >= 0; j--)
                {
                        if (mat[i,j]%2==0)
                        {
                        count++;
                        }
                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

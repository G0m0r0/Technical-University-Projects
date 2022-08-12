using System;

namespace first
{
    class Program
    {
        static void twoDArray(decimal[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i > j)
                    {
                        matrix[i, j] = 4 * j + (decimal)Math.Pow(i, 3);
                    }
                    else if (i == j)
                    {
                        matrix[i, j] = 0;
                    }
                    else if (i < j) matrix[i, j] = i + j;
                }
            }
        }
        static decimal matrixSum(decimal[,] matrix)
        {
            decimal sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if(matrix[i,j]>0)
                        if(i%2!=0||j%2!=0)
                        {
                            sum += matrix[i, j];
                        }
                        
                }
            }
            return sum;
        }
        static decimal matrixMul(decimal[,] matrix)
        {
            decimal mul = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] != 0)
                        if (i % 2 == 0 || j % 2 == 0)
                        {
                            mul *= matrix[i, j];
                        }
                }
            }
            return mul;
        }
        static decimal maxNegativeElement(decimal[,] mat)
        {
            decimal maxNegative = decimal.MinValue;
            for (int i = 0; i < mat.GetLength(1); i++)    
            {
                for (int j = 0; j < mat.GetLength(0); j++)
                {
                    if (mat[i, j] < 0)
                        if (mat[i, j] > maxNegative)
                        {
                            maxNegative = mat[i, j];
                        }
                }
            }
            return maxNegative;
        }
        static bool minPositiveIndex(decimal[,] matrix,ref int minI,ref int minJ)
        {
            decimal minPositive = decimal.MaxValue;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] > 0) //proverka za vsi4ki positivni elementi
                        if (matrix[i, j] < minPositive) //nai malkiq element
                        {
                            minPositive = matrix[i, j];
                            minJ = j;
                            minI = i;
                        }
                }
            }
            if (minPositive == decimal.MaxValue)
            {
                return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            
        }
    }
}

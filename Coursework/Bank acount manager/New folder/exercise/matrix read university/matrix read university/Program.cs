using System;
using System.IO;

namespace matrix_read_write_exam
{
    class Program
    {

        static void Output(decimal[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void InputMatrix(string path, ref decimal[,] matrix, ref int n, ref int m)
        {
            using (StreamReader reader = File.OpenText(path))
            {
                string text = reader.ReadToEnd();
                int i = 0, j = 0;
                int counter = 1;
                foreach (var row in text.Split('\n'))
                {
                    if (counter == 1)
                    {
                        n = int.Parse(row);
                        counter++;
                        continue;
                    }
                    else if (counter == 2)
                    {
                        m = int.Parse(row);
                        matrix = new decimal[n, m];
                        counter++;
                        continue;
                    }
                    if (row == "") break;
                    j = 0;
                    foreach (var col in row.Trim().Split(' '))
                    {
                        matrix[i, j] = Convert.ToDecimal(col.Trim());
                        j++;
                    }
                    i++;
                }
            }
        }
        static bool CheckIdentity(decimal[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j && matrix[i, j] != 1) return false;
                    else if (i != j && matrix[i, j] != 0) return false;
                }
            }
            return true;
        }
        static decimal SumNegativeOnAntiDiagonal(decimal[,] matrix)
        {
            decimal sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i + j == matrix.GetLength(0) - 1 && matrix[i, j] < 0) sum += matrix[i, j];
                }
            }
            return sum;
        }
        static void NormalizeRows(decimal[,] matrix)
        {
            decimal sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += (matrix[i, j] * matrix[i, j]);
                    if (j == matrix.GetLength(1) - 1)
                    {
                        if (i != 0) Console.WriteLine(Math.Sqrt(((double)sum) / i));
                        else Console.WriteLine(Math.Sqrt((double)sum));
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter path to file: ");
            string path = Console.ReadLine();
            int n = 0;
            int m = 0;
            decimal[,] matrix = new decimal[n, m];
            InputMatrix(path, ref matrix, ref n, ref m);
            Output(matrix);
            Console.WriteLine(CheckIdentity(matrix));
            Console.WriteLine("Sum of negative numbers of anti diagonal is {0}", SumNegativeOnAntiDiagonal(matrix));
            NormalizeRows(matrix);
            //D:\\test.txt
        }
    }
}

using System;
using System.IO;

namespace Matrix_from_file
{
    class Program
    {
        static void ReadMatrix(double[,] matrix)
        {
            using (StreamReader reader = new StreamReader("D:\\test.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] splitedArray = line.Split('\t');
                    int i = 0, j = 0;
                    int counter = 1;
                    foreach (string x in splitedArray)
                    {
                        
                        if (counter == 1) i = int.Parse(x);
                        else if (counter == 2) j = int.Parse(x);
                        else if(counter==3)
                        {
                            matrix[i, j] = double.Parse(x);
                            counter = 1;
                        }
                        counter++;
                    }
                }
            }
        }
        static void PrintMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]+" ");
                }
                Console.WriteLine();
            }
        }
        static void SumOfEvenAndOdd(double[,] matrix,ref double sumEven,ref double sumOdd)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] % 2 == 0)  sumEven += matrix[i, j];
                    else sumOdd += matrix[i, j];
                }
            }       
        }
        static void evenRowsAndOddColoms(double[,] matrix,ref double SumOfEvenRows,ref double sumOfOddColoms)
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i % 2 == 0) SumOfEvenRows += matrix[i, j];
                    if (j % 2 != 0) sumOfOddColoms += matrix[i, j];
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of matrix");
            int n = int.Parse(Console.ReadLine());
            double[,] matrix = new double[n, n];
            double sumEven=0, sumOdd=0;
            double sumEvenRows = 0, sumOddColoms = 0;
            ReadMatrix(matrix);
            PrintMatrix(matrix);
            SumOfEvenAndOdd(matrix, ref sumEven, ref sumOdd);
            Console.WriteLine("Sum of even is: "+sumEven);
            Console.WriteLine("Sum of odd is: "+sumOdd);
            evenRowsAndOddColoms(matrix, ref sumEvenRows, ref sumOddColoms);
            Console.WriteLine("Sum of even rows: "+sumEvenRows);
            Console.WriteLine("Sum of odd coloms: "+sumOddColoms);
        }
    }
}

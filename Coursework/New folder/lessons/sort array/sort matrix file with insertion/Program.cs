using System;
using System.IO;
namespace sort_matrix_file_with_insertion
{
    class Program
    {
        static void InputMatrix(string path,int n, double[,] matrix)
        {
            int i=0,j= 0;
            using (StreamReader reader = new StreamReader(path))
            {
                do
                {
                    string line = reader.ReadLine();
                    j = 0;
                    foreach(var element in line.Split(' '))
                    {
                        matrix[i, j] = double.Parse(element);
                            j++;
                    }
                    i++;
                } while (!reader.EndOfStream);
            }
        }
        static void output(double[,] matrix)
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
        static void CreateArray(double[,] matrix,ref double[] array)
        {
            int n = matrix.GetLength(0) * matrix.GetLength(1);
            array = new double[n];
            int counter = 0;
            for (int  i = 0;  i <matrix.GetLength(0);  i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    array[counter] = matrix[i, j];
                        counter++;
                }
            }
        }
        static void outputArray(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]+" ");
            }
        }
        static void insertionSort(double[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int hole = i;
                double value = array[i];
                while(hole>0&&array[hole]>value)
                {
                    array[hole] = array[hole - 1];
                    --hole;
                }
                array[hole] = value;
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter size of matrix: ");
            int n = int.Parse(Console.ReadLine());
            string path = "D:\\test.txt";
            double[,] matrix = new double[n, n];
            double[] array = new double[n*n];
            InputMatrix(path, n, matrix);
            output(matrix);
            CreateArray(matrix, ref array);
            outputArray(array);
            insertionSort(array);
            Console.WriteLine();
            outputArray(array);
        }
    }
}

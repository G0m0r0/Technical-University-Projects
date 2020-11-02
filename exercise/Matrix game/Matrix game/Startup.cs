
namespace Matrix_game
{
    using MathNet.Numerics.LinearAlgebra;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        private static int[,] matrix;
        private static string[] rowsUknown;
        private static string[] colsUknown;
        static void Main()
        {
            var data = File.ReadAllText("../../../input.txt");
            int n = data.Split(Environment.NewLine).Length;
            int m = data.Split(Environment.NewLine)[0].Split().Length;
            matrix = new int[n, m];
            rowsUknown = new string[n];
            colsUknown = new string[m];


            FillMatrix(data);


            var A = Matrix<double>.Build.DenseOfArray(new double[,] {
    { 3, 2, -1 },
    { 2, -2, 4 },
    { -1, 0.5, -1 }
});


            rowsUknown[0] = "x";
            rowsUknown[1] = "0";
            rowsUknown[2] = "1-x";

            colsUknown[0] = "y";
            colsUknown[1] = "1-y";
            colsUknown[2] = "0";

            CalculateData();

            PrintMatrix();
        }

        private static void CalculateData()
        {
            // var equasion=
        }

        private static void PrintMatrix()
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

        private static void FillMatrix(string dataInput)
        {
            var data = dataInput.Split(Environment.NewLine);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = data[i].Split().Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }
        }
    }
}

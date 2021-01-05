
namespace Matrix_game
{
    using MathNet.Numerics.LinearAlgebra;
    using Symbolism;
    using Symbolism.AlgebraicExpand;
    using Symbolism.IsolateVariable;
    using Symbolism.RationalExpand;
    using Symbolism.RationalizeExpression;
    using Symbolism.Utils;
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        private static int[,] matrix;
        private static MathObject[] vectors;
        static void Main()
        {
            var data = File.ReadAllText("../../../input.txt");
            int n = data.Split(Environment.NewLine).Length;
            int m = data.Split(Environment.NewLine)[0].Split().Length;
            vectors = new MathObject[n];
            matrix = new int[n, m];

            FillMatrix(data);

            PrintEquastionsForGraphics();

            //GoToSite("https://www.desmos.com/calculator");

            CalculateXOrY();

            CalculateV();

            CalculateData();

            //PrintMatrix();
        }

        private static void CalculateV()
        {
            var y = new Symbol("y");
            var V = (vectors[0] * y - vectors[1] * (y - 1) - vectors[2] * 0)
                .AlgebraicExpand();


            Console.WriteLine("V = " + V);
        }

        private static void CalculateXOrY()
        {
            var x = new Symbol("x");
            var L1 = (vectors[0] - vectors[1])
                .AlgebraicExpand();

            Regex rx = new Regex(@"((\+|-)?([0-9]+)(\.[0-9]+)?)|((\+|-)?\.?[0-9]+)");
            var match = double.Parse(rx.Match(L1.ToString()).ToString());

            if (L1.ToString().Where(x => x == '-').Count() % 2 == 0)
            {
                Console.WriteLine("x = " + match);
            }
            else
            {
                Console.WriteLine("x = " + match.ToString().Replace('-', ' '));
            }

            Console.WriteLine($"X Opt ( {match} , 0 , {match - 1} )");
        }

        public static void GoToSite(string url)
        {
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = url;
            System.Diagnostics.Process.Start(psi);
        }

        private static void PrintEquastionsForGraphics()
        {
            var x = new Symbol("x");
            var xMinusOne = x - 1;
            var L1 = (matrix[0, 0] * x + matrix[1, 0] * 0 + matrix[2, 0] * xMinusOne)
                .AlgebraicExpand();
            vectors[0] = L1;
            Console.WriteLine("l1: " + L1);

            var L2 = (matrix[0, 1] * x + matrix[1, 1] * 0 + matrix[2, 1] * xMinusOne)
               .AlgebraicExpand();
            vectors[1] = L2;
            Console.WriteLine("l2: " + L2);

            var L3 = (matrix[0, 2] * x + matrix[1, 2] * 0 + matrix[2, 2] * xMinusOne)
               .AlgebraicExpand();
            vectors[2] = L3;
            Console.WriteLine("l3: " + L3);
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

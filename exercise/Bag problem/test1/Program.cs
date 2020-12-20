using System;

namespace test1
{
    class Program
    { 
        public class Knapsack
        {
            public static void Main()
            {
                int w = 60;                
                int[] val = { 17, 13, 15,11,18};                
                int[] wt = { 23,31,41,37,29 };
                int n = val.Length;

                // Populate base cases
                int[,] mat = new int[n + 1,w + 1];
                for (int r = 0; r < w + 1; r++)
                {
                    mat[0,r] = 0;
                }
                for (int c = 0; c < n + 1; c++)
                {
                    mat[c,0] = 0;
                }

                // Main logic
                for (int item = 1; item <= n; item++)
                {
                    for (int capacity = 1; capacity <= w; capacity++)
                    {
                        int maxValWithoutCurr = mat[item - 1,capacity]; // This is guaranteed to exist
                        int maxValWithCurr = 0; // We initialize this value to 0

                        int weightOfCurr = wt[item - 1]; // We use item -1 to account for the extra row at the top
                        if (capacity >= weightOfCurr)
                        { // We check if the knapsack can fit the current item
                            maxValWithCurr = val[item - 1]; // If so, maxValWithCurr is at least the value of the current item

                            int remainingCapacity = capacity - weightOfCurr; // remainingCapacity must be at least 0
                            maxValWithCurr += mat[item - 1,remainingCapacity]; // Add the maximum value obtainable with the remaining capacity
                        }

                        mat[item,capacity] = Math.Max(maxValWithoutCurr, maxValWithCurr); // Pick the larger of the two
                    }
                }

                Console.WriteLine(mat[n,w]);  // Final answer
                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    for (int j = 0; j < mat.GetLength(1); j++)
                    {
                        Console.Write(mat[i,j]+" ");

                    }
                    Console.WriteLine();
                }// Visualization of the table
            }
        }
    }
}

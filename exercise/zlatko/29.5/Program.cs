using System;
using System.Collections.Generic;
using System.Linq;

namespace _29._5
{
    class Program
    {
        static void Main(string[] args)
        {
            // 29/5

            Console.WriteLine("Enter number of pairs");
            int numOfPairs = int.Parse(Console.ReadLine());

            List<string> pairs = new List<string>();
            Console.WriteLine("Enter pairs separeted by space");

            for (int i = 0; i <numOfPairs; i++)
            {
                pairs.Add(Console.ReadLine());
            }

            double maxDiam = 0;
            for (int i = 1; i < pairs.Count-1; i++)
            {
                for (int j = 0; j < pairs.Count; j++)
                {
                    if (i == j || i == j - 1 || i == j + 1)
                        continue;

                    else
                    {
                        int[] xy1 = pairs[i].Split().Select(int.Parse).ToArray();
                        int[] xy2 = pairs[j].Split().Select(int.Parse).ToArray();

                        int x = xy2[0] - xy1[0];
                        int y = xy2[1] - xy1[1];
                        double lengh = Math.Sqrt(x * x + y * y);
                        if (lengh > maxDiam)
                            maxDiam = lengh;
                    }
                }
            }
            Console.WriteLine($"Longest diametar is {maxDiam}");
        }
    }
}

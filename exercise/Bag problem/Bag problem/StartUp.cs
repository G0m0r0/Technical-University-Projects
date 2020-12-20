namespace Bag_problem
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static Bag bag;

        static void Main()
        {
            InitializeBag();

            int[] val = new int[] { bag.Products[0].Value, bag.Products[1].Value, bag.Products[2].Value };
            int[] wt = new int[] { bag.Products[0].Weight, bag.Products[1].Weight, bag.Products[2].Weight };
            int W = bag.MaxWeight;
            int n = val.Length;

            Console.WriteLine(knapSack(W, wt, val, n));
        }

        static int max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        // Returns the maximum value that can 
        // be put in a knapsack of capacity W 
        static int knapSack(int W, int[] wt,
                            int[] val, int n)
        {

            // Base Case 
            if (n == 0 || W == 0)
                return 0;

            // If weight of the nth item is 
            // more than Knapsack capacity W, 
            // then this item cannot be 
            // included in the optimal solution 
            if (wt[n - 1] > W)
                return knapSack(W, wt,
                                val, n - 1);

            // Return the maximum of two cases: 
            // (1) nth item included 
            // (2) not included 
            else
                return max(val[n - 1]
                           + knapSack(W - wt[n - 1], wt,
                                      val, n - 1),
                           knapSack(W, wt, val, n - 1));
        }

        private static void InitializeBag()
        {
            Console.Write("Type the total weight of the bag? ");
            var maxWeight = int.Parse(Console.ReadLine());
            bag = new Bag(maxWeight);

            while (true)
            {
                InitializeProduct();

                Console.WriteLine("Do you have more products? Type \"Exit\" to exit or press enter.");
                var more = Console.ReadLine().ToLower();

                if (more.Contains("exit"))
                {
                    break;
                }
            }
        }

        private static void InitializeProduct()
        {
            Console.Write("Weight= ");
            var weight = int.Parse(Console.ReadLine());

            Console.Write("Value= ");
            var value = int.Parse(Console.ReadLine());

            var product = new Product(weight, value);

            bag.Products.Add(product);
        }
    }
}

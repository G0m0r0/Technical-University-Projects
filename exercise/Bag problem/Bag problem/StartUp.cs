namespace Bag_problem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static Bag bag;

        static void Main()
        {
            InitializeBag();

            var bagValues = bag
                .Products
                .Select(x => x.Value)
                .ToList();

            var bagWeights = bag
                .Products
                .Select(x => x.Weight )
                .ToList();

            int maxValue = BagProblemMaxValue(bag.MaxWeight, bagWeights, bagValues, bagValues.Count);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Answer= "+maxValue);
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

        static int BagProblemMaxValue(int maxWeight, List<int> bagWeights, List<int> bagValues, int numberValues)
        {
            if (numberValues == 0 || maxWeight == 0)
            {
                return 0;
            }

            if (bagWeights[numberValues - 1] > maxWeight)
            {
                return BagProblemMaxValue(maxWeight, bagWeights, bagValues, numberValues - 1);
            }
            else
            {
                return max(bagValues[numberValues - 1]
                    + BagProblemMaxValue(maxWeight - bagWeights[numberValues - 1], 
                           bagWeights,
                           bagValues, numberValues - 1),
                           BagProblemMaxValue(maxWeight, bagWeights, bagValues, numberValues - 1));
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

        static int max(int firstNumber, int secondNumber)
        {
            return (firstNumber > secondNumber) ?
                firstNumber :
                secondNumber;
        }
    }
}

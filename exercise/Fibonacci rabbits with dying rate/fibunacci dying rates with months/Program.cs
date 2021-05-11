using System;
using System.Collections.Generic;
using System.Linq;

namespace fibunacci_dying_rates_with_months
{
    class Program
    {
        static void Main()
        {
            var fibonacciSequence = new List<long>() { 0, 1 };
            Console.Write("Total years for reprocreating: ");
            var monthsForProcreating = getMonthsFromImput(Console.ReadLine())-1; //substract 1 bcs we have one element
            Console.Write("Max year rabbit is alive: ");
            var maxMonthsRabbitIsAlive = getMonthsFromImput(Console.ReadLine());

            Console.WriteLine(monthsForProcreating);
            Console.WriteLine(maxMonthsRabbitIsAlive);

            long totalRabbitsborn = 1; //we have in the inital sequence
            //years to procreate
            long rabbitsBornForCurrentMonth = 0;
            for (int i = 1; i <= monthsForProcreating; i++)
            {
                if (i >= maxMonthsRabbitIsAlive)
                {
                     long deadRabbitsToSubstract = fibonacciSequence[i - maxMonthsRabbitIsAlive+1];
                     rabbitsBornForCurrentMonth =
                     fibonacciSequence[fibonacciSequence.Count - 1] +
                     fibonacciSequence[fibonacciSequence.Count - 2]-deadRabbitsToSubstract;
                }
                else
                {
                    rabbitsBornForCurrentMonth =
                    fibonacciSequence[fibonacciSequence.Count - 1] +
                    fibonacciSequence[fibonacciSequence.Count - 2];
                }

                totalRabbitsborn += rabbitsBornForCurrentMonth;

                fibonacciSequence.Add(rabbitsBornForCurrentMonth);
            }

            Console.WriteLine(string.Join(" ", fibonacciSequence));
            Console.WriteLine($"\nTotal rabbits born {totalRabbitsborn}");
            Console.WriteLine($"\nTotal rabbits alive {fibonacciSequence.Last()}");

            var fibonacciSequence2 = new List<long>() { 0, 1 };
            long totalRabbitsBorn2 = 0;
            for (int i = 1; i <= monthsForProcreating; i++)
            {
                //procreating every month
                var rabbitsBornForCurrentMonth2 = 
                    fibonacciSequence2[fibonacciSequence2.Count - 1] + 
                    fibonacciSequence2[fibonacciSequence2.Count - 2];

                totalRabbitsBorn2 += rabbitsBornForCurrentMonth2;

                fibonacciSequence2.Add(rabbitsBornForCurrentMonth2);
            }

            Console.WriteLine(string.Join(" ", fibonacciSequence2));
            Console.WriteLine($"\nTotal rabbits born {totalRabbitsBorn2}(with no dying rate)");
            Console.WriteLine($"\nTotal rabbits alive {fibonacciSequence2.Last()}(with no dying rate)");
        }

        private static int getMonthsFromImput(string input)
        {
            double doubleNumber = double.Parse(input);
            int intPart = (int)doubleNumber;
            double doublePart = doubleNumber - intPart;

            int result = 0;
            if (doublePart < 0 || doublePart >= 0.12)
            {
                Console.WriteLine("Wrong input!");
            }
            else
            {
                result = intPart*12 + (int)(doublePart * 100);
            }

            return result;
        }
    }
}

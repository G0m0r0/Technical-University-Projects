namespace Fibonacci_Rabbits_Dying_After_Arbitrary
{
    using System.Linq;
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            //..............................
            //This is only test program. Fibunacci dying rates with months is the real one.
            //..............................
            var fibonacciSequence = new List<long>() { 0, 1 };
            Console.Write("Total years for reprocreating: ");
            var monthsForProcreating = double.Parse(Console.ReadLine()) * 12;
            Console.Write("Max year rabbit is alive: ");
            var maxMonthsRabbitIsAlive = double.Parse(Console.ReadLine()) * 12;

            //years to procreate
            for (int i = 1; i <= monthsForProcreating; i++)
            {
                //procreating every month
                fibonacciSequence.Add(fibonacciSequence[fibonacciSequence.Count - 1] + fibonacciSequence[fibonacciSequence.Count - 2]); 
            }

            Console.WriteLine(string.Join(" ", fibonacciSequence));
            Console.WriteLine($"\nTotal rabbits alive {fibonacciSequence.TakeLast((int)Math.Floor(maxMonthsRabbitIsAlive)).Sum()}");        
            Console.WriteLine($"\nTotal rabbits dead " +
                $"{fibonacciSequence.Sum() - fibonacciSequence.TakeLast((int)Math.Floor(maxMonthsRabbitIsAlive)).Sum()}");
            Console.WriteLine($"\nTotal rabbits born {fibonacciSequence.Sum()}");
        }
    }
}

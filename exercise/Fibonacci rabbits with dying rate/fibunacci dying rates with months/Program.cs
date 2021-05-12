using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace fibunacci_dying_rates_with_months
{
    class Program
    {
        static void Main()
        {            
            do
            {
                var fibonacciSequence = new List<ulong>() { 0, 1 };
                Console.Write("Total years for reprocreating: ");
                int monthsForProcreating = getMonthsFromImput(Console.ReadLine()) - 1; //substract 1 bcs we have one element
                Console.Write("Max year rabbit is alive: ");
                int maxMonthsRabbitIsAlive = getMonthsFromImput(Console.ReadLine());
                
                if(monthsForProcreating < 0 || maxMonthsRabbitIsAlive < 0 || monthsForProcreating+1 < maxMonthsRabbitIsAlive)
                {
                    DisplayMessage(ConsoleColor.Red, ConsoleColor.White, "Wrong input data, please try again!\n");
                    continue;
                }

                var fibonacciSequence2 = new List<ulong>() { 0, 1 };
                for (int i = 1; i <= monthsForProcreating; i++)
                {
                    //procreating every month
                    var rabbitsBornForCurrentMonth2 =
                        fibonacciSequence2[fibonacciSequence2.Count - 1] +
                        fibonacciSequence2[fibonacciSequence2.Count - 2];

                    fibonacciSequence2.Add(rabbitsBornForCurrentMonth2);
                }

                DisplayMessage(ConsoleColor.Blue, ConsoleColor.White, "\n..................RABBITS WITH DYING RATE..................");

                //years to procreate
                ulong rabbitsBornForCurrentMonth = 0;
                for (int i = 1; i <= monthsForProcreating; i++)
                {
                    if (i >= maxMonthsRabbitIsAlive)
                    {
                        ulong deadRabbitsToSubstract = fibonacciSequence[i - maxMonthsRabbitIsAlive + 1];
                        rabbitsBornForCurrentMonth =
                        fibonacciSequence[fibonacciSequence.Count - 1] +
                        fibonacciSequence[fibonacciSequence.Count - 2] - deadRabbitsToSubstract;
                    }
                    else
                    {
                        rabbitsBornForCurrentMonth =
                        fibonacciSequence[fibonacciSequence.Count - 1] +
                        fibonacciSequence[fibonacciSequence.Count - 2];
                    }

                    fibonacciSequence.Add(rabbitsBornForCurrentMonth);
                }

                DisplayOutputData(fibonacciSequence, fibonacciSequence.Last(), fibonacciSequence2.Last(), fibonacciSequence2.Last() - fibonacciSequence.Last(), maxMonthsRabbitIsAlive);

                DisplayMessage(ConsoleColor.Blue, ConsoleColor.White, "..................RABBITS WIHT NO DYING RATE..................\n");

                DisplayOutputData(fibonacciSequence2, fibonacciSequence2.Last(), fibonacciSequence2.Last(), 0, maxMonthsRabbitIsAlive);

                DisplayMessage(ConsoleColor.DarkGreen, ConsoleColor.White, 
                    "Do you want to continue with the program?\nType 'Y' for YES and 'N' for no.");

                var userInput = Console.ReadLine();
                if (userInput.ToLower() == "y")
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    break;
                }

            } while (true);

        }

        private static void DisplayMessage(ConsoleColor backgroundColor, ConsoleColor foregroundColor, string message)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void DisplayOutputData(List<ulong> fibonacciSequence, ulong aliveRabbits, ulong bornRabbits, ulong deadRabbits, int maxMonthsRabbitIsAlive)
        {
            Console.WriteLine(string.Join(" ", fibonacciSequence.Take(5)) + " ... " + string.Join(" ", fibonacciSequence.TakeLast(5)) + "\n");
            Console.WriteLine($"Total rabbits alive {aliveRabbits}");
            Console.WriteLine($"Total rabbits born {bornRabbits}");

            if (deadRabbits == 0)
            {
                Console.WriteLine($"Total rabbits dead {deadRabbits}\n");
            }
            else
            {
                string extention;

                var aliveTimeStr = maxMonthsRabbitIsAlive.ToString();

                switch (aliveTimeStr.Substring(aliveTimeStr.Length - 1))
                {
                    case "1":
                        extention = "st";
                        break;
                    case "2":
                        extention = "nd";
                        break;
                    default:
                        extention = "th";
                        break;
                }

                switch (aliveTimeStr.Substring(aliveTimeStr.Length - 2))
                {
                    case "11": extention = "th";
                        break;
                    case "12": extention = "th";
                        break;
                }

                var result = $"Total rabbits dead {deadRabbits} " +
                $"(Start dying on {maxMonthsRabbitIsAlive}{extention} month.)\n";

                Console.WriteLine(result);
            }
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
                result = intPart * 12 + (int)(doublePart * 100);
            }

            return result;
        }
    }
}

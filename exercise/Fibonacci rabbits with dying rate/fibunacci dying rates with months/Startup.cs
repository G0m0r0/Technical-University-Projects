namespace fibunacci_dying_rates_with_months
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            do
            {
                var fibonacciSequence = new List<ulong>() { 0, 1 };
                var fibonacciSequence2 = new List<ulong>() { 0, 1 };

                Console.Write(ConstMessages.totalYearForReprocreating);
                int monthsForProcreating = getMonthsFromImput(Console.ReadLine()) - 1; //substract 1 bcs we have one element
                Console.Write(ConstMessages.maxYearRabbitIsAlive);
                int maxMonthsRabbitIsAlive = getMonthsFromImput(Console.ReadLine());

                if (monthsForProcreating < 0.03 ||
                    maxMonthsRabbitIsAlive < 0.03 ||
                    monthsForProcreating + 1 < maxMonthsRabbitIsAlive)
                {
                    DisplayMessage(ConsoleColor.Red, 
                        ConsoleColor.White,
                        ConstMessages.wrongInputData);
                    continue;
                }
                //Console.Clear();

                DisplayMessage(ConsoleColor.Blue, 
                    ConsoleColor.White,
                   ConstMessages.rabbitsWithDyingRate);

                //time to procreate
                ulong rabbitsBornForCurrentMonth;
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

                    fibonacciSequence2.Add(fibonacciSequence2[fibonacciSequence2.Count - 1] +
                        fibonacciSequence2[fibonacciSequence2.Count - 2]);

                    fibonacciSequence.Add(rabbitsBornForCurrentMonth);
                }

                DisplayOutputData(fibonacciSequence, 
                    fibonacciSequence.Last(), 
                    fibonacciSequence2.Last(), 
                    fibonacciSequence2.Last() - fibonacciSequence.Last(), 
                    maxMonthsRabbitIsAlive);

                DisplayMessage(ConsoleColor.Blue, 
                    ConsoleColor.White, 
                    ConstMessages.rabbitsWithNoDyingRate);

                DisplayOutputData(fibonacciSequence2, 
                    fibonacciSequence2.Last(), 
                    fibonacciSequence2.Last(), 
                    0, 
                    maxMonthsRabbitIsAlive);

                DisplayMessage(ConsoleColor.DarkGreen, 
                    ConsoleColor.White,
                    ConstMessages.DoYouWantToContiue);

                var userInput = Console.ReadLine();
                if (userInput.ToLower() == ConstMessages.y || 
                    userInput.ToLower() == ConstMessages.yes)
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
            if (fibonacciSequence.Count > 5)
            {
                Console.WriteLine(string.Join(" ", fibonacciSequence.Take(5)) + " ... " + string.Join(" ", fibonacciSequence.TakeLast(5)) + "\n");
            }
            else
            {
                Console.WriteLine(string.Join(" ", fibonacciSequence.Take(5)));
            }

            Console.WriteLine(string.Format(ConstMessages.totalRabbitsAlive,aliveRabbits));
            Console.WriteLine(string.Format(ConstMessages.totalRabbitsBorn,bornRabbits));

            if (deadRabbits == 0)
            {
                Console.WriteLine(string.Format(ConstMessages.totalRabbitsDead,deadRabbits));
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
                    case "3":
                        extention = "rd";
                        break;
                    default:
                        extention = "th";
                        break;
                }

                if (aliveTimeStr.Length > 1)
                    switch (aliveTimeStr.Substring(aliveTimeStr.Length - 2))
                    {
                        case "11":
                            extention = "th";
                            break;
                        case "12":
                            extention = "th";
                            break;
                        case "13":
                            extention = "th";
                            break;
                    }

                var result =string.Format(ConstMessages.totalRabbitsDeadWithDyingRate,deadRabbits,maxMonthsRabbitIsAlive,extention);

                Console.WriteLine(result);
            }
        }

        private static int getMonthsFromImput(string input)
        {
            double doubleNumber = double.Parse(input);
            int intPart = (int)doubleNumber;
            double doublePart = doubleNumber - intPart;

            int result;
            if (doublePart < 0 || doublePart >= 0.12)
            {
                return -1;
            }
            else
            {
                result = intPart * 12 + (int)(doublePart * 100);
            }

            return result;
        }
    }
}

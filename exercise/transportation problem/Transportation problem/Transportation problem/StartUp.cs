namespace Transportation_problem
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;

    class StartUp
    {
        private static List<int> producer = new List<int>();
        private static List<int> receiver = new List<int>();
        private static int[,] timeTable;
        private static int[,] valueTable;
        static void Main()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            ReadData();

            CreateMissingRowCol();

            FillTimeTable();
            Console.WriteLine();
            CalculateValues();

            PrintValueTable();

            Console.WriteLine();
            Console.WriteLine($"Max value: {TakeMaxValue()}");
            Console.WriteLine();
            Console.WriteLine(stopWatch.Elapsed);
        }

        private static void CalculateValues()
        {
            int indexI = 0;
            int indexJ = 0;
            while (GetIndexMinValueTimeTable(ref indexI, ref indexJ))
            {
                if (producer[indexI] < receiver[indexJ])
                {
                    valueTable[indexI, indexJ] = producer[indexI];
                    receiver[indexJ] -= producer[indexI];
                    producer[indexI] -= producer[indexI];
                }
                else if (producer[indexI] > receiver[indexJ])
                {
                    valueTable[indexI, indexJ] = receiver[indexJ];

                    producer[indexI] -= receiver[indexJ];
                    receiver[indexJ] -= receiver[indexJ];
                }
                else
                {
                    valueTable[indexI, indexJ] = receiver[indexJ];
                    producer[indexI] = 0;
                    receiver[indexJ] = 0;
                }

                if (producer[indexI] == 0)
                {
                    for (int i = 0; i < valueTable.GetLength(1); i++)
                    {
                        if (valueTable[indexI, i] == 0)
                            valueTable[indexI, i] = -1;
                    }
                }

                if (receiver[indexJ] == 0)
                {
                    for (int j = 0; j < valueTable.GetLength(0); j++)
                    {
                        if (valueTable[j, indexJ] == 0)
                            valueTable[j, indexJ] = -1;
                    }
                }
            }
        }

        private static bool GetIndexMinValueTimeTable(ref int indexI, ref int indexJ)
        {
            int minValue = int.MaxValue;
            bool hasMinValue = false;

            for (int i = 0; i < timeTable.GetLength(0); i++)
            {
                for (int j = 0; j < timeTable.GetLength(1); j++)
                {
                    if (minValue >= timeTable[i, j] && valueTable[i, j] == 0)
                    {
                        indexI = i;
                        indexJ = j;
                        minValue = timeTable[i, j];
                        hasMinValue = true;
                    }
                }
            }

            return hasMinValue;
        }

        private static int TakeMaxValue()
        {
            int maxTimeValue = int.MinValue;

            for (int i = 0; i < timeTable.GetLength(0); i++)
            {
                for (int j = 0; j < timeTable.GetLength(1); j++)
                {
                    if (valueTable[i, j] > 0)
                    {
                        if (maxTimeValue < timeTable[i, j])
                        {
                            maxTimeValue = timeTable[i, j];
                        }
                    }
                }
            }

            return maxTimeValue;
        }

        private static void CreateMissingRowCol()
        {
            int differentQuantities = producer.Sum() - receiver.Sum();

            if (differentQuantities > 0)
            {
                receiver.Add(differentQuantities);
            }
            else if (differentQuantities < 0)
            {
                producer.Add(Math.Abs(differentQuantities));
            }

            timeTable = new int[producer.Count(), receiver.Count()];
            valueTable = new int[producer.Count(), receiver.Count()];
        }

        private static void ReadData()
        {
            Console.Write("AT= ");
            producer = File.ReadAllText("../../../ProducerValues.txt").Split().Select(int.Parse).ToList();
            Console.Write(string.Join(' ', producer));
            Console.WriteLine($"  Sum: {producer.Sum()}");
            Console.Write("B= ");
            receiver = File.ReadAllText("../../../ReceiverValues.txt").Split().Select(int.Parse).ToList();
            Console.Write(string.Join(' ', receiver));
            Console.WriteLine($"   Sum: {receiver.Sum()}");

            Console.WriteLine();
            Console.WriteLine("Enter time table:");
        }

        private static void PrintValueTable()
        {
            var sb = new StringBuilder();
            sb.Append("   ");
            for (int i = 1; i <= valueTable.GetLength(1); i++)
            {
                sb.Append($"B{i}   ");
            }

            Console.WriteLine(sb.ToString());
            for (int i = 0; i < valueTable.GetLength(0); i++)
            {
                Console.Write($"A{++i} ");
                i--;
                for (int j = 0; j < valueTable.GetLength(1); j++)
                {
                    int valueLength = 5;
                    if (j == 0)
                    {
                        valueLength = 5;
                    }
                    else
                    {
                        valueLength = valueTable[i, --j].ToString().Length - 1;
                        j++;
                    }

                    if (valueTable[i, j] == -1)
                    {
                        Console.Write(new String(' ', 5 - valueLength) + "0");
                    }
                    else
                    {
                        Console.Write(new String(' ', 5 - valueLength) + valueTable[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }

        private static void FillTimeTable()
        {
            var valuesRows = File.ReadAllText("../../../TimeValues.txt").Split(Environment.NewLine).ToList();

            if (valuesRows.Count != producer.Count)
            {
                valuesRows.Add(string.Concat(Enumerable.Repeat("0 ", receiver.Count)));
            }

            for (int i = 0; i < producer.Count(); i++)
            {
                var row = valuesRows[i]
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                if (row.Count != receiver.Count)
                {
                    row.Add(0);
                }

                for (int j = 0; j < receiver.Count(); j++)
                {
                    timeTable[i, j] = row[j];
                    Console.Write($"{timeTable[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}

namespace Transportation_problem
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    class StartUp
    {
        private static Dictionary<int, int>[,] table;
        private static List<int> producer = new List<int>();
        private static List<int> receiver = new List<int>();
        private static int[,] timeTable;
        private static int[,] valueTable;
        static void Main()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            Console.Write("AT= ");
            producer = Console.ReadLine().Split().Select(int.Parse).ToList();
            Console.Write("B= ");
            receiver = Console.ReadLine().Split().Select(int.Parse).ToList();

            table = new Dictionary<int, int>[producer.Count(), receiver.Count()];
            timeTable = new int[producer.Count(), receiver.Count()];
            valueTable = new int[producer.Count(), receiver.Count()];

            Console.WriteLine();
            Console.WriteLine("Enter time table:");
            FillTimeTable();
            CalculateValues();

            // CircleDataToFindMinTimeValue();

            //Console.WriteLine();
          //  PrintValueTable();

            Console.WriteLine();
            Console.WriteLine(stopWatch.Elapsed);
        }

        private static void CircleDataToFindMinTimeValue()
        {
            int indexI = 0;
            int indexJ = 0;
            int maxTime = FindMaxTimeWithValue(ref indexI, ref indexJ);

            SquareAlgorithm(maxTime, indexI, indexJ);
        }

        private static void SquareAlgorithm(int maxTime, int indexI, int indexJ)
        {
            for (int j = indexI; j < valueTable.GetLength(0); j++)
            {
                if (valueTable[indexI, j] != -1)
                {
                    for (int k = 0; k < valueTable.GetLength(1); k++)
                    {

                    }
                }
            }
        }
        private static bool ValidCell(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return false;
            }
            if (x > valueTable.GetLength(0) - 1 || y > valueTable.GetLength(1) - 1)
            {
                return false;
            }

            return true;
        }

        private static int FindMaxTimeWithValue(ref int indexI, ref int indexJ)
        {
            int maxValueTime = int.MinValue;
            for (int i = 0; i < timeTable.GetLength(0); i++)
            {
                for (int j = 0; j < timeTable.GetLength(1); j++)
                {
                    if (valueTable[i, j] > 0 && maxValueTime < timeTable[i, j])
                    {
                        maxValueTime = timeTable[i, j];
                        indexI = i;
                        indexJ = j;
                    }
                }
            }

            return maxValueTime;
        }

        private static void PrintValueTable()
        {
            Console.WriteLine("X0  B1  B2  B3");
            for (int i = 0; i < valueTable.GetLength(0); i++)
            {
               // Console.Write($"A{++i} ");
                // i--;
                for (int j = 0; j < valueTable.GetLength(1); j++)
                {
                    if (valueTable[i, j] == -1)
                    {
                        Console.Write("  0 ");
                    }
                    else
                    {
                        Console.Write(valueTable[i, j] + "  ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void FillTimeTable()
        {
            for (int i = 0; i < producer.Count(); i++)
            {
                var row = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < receiver.Count(); j++)
                {
                    timeTable[i, j] = row[j];
                }
            }
        }

        private static void CalculateValues()
        {
            int indexI = 0;
            int indexJ = 0;
            int minValue = int.MaxValue;
            while (GetIndexMinValueTimeTable(ref indexI, ref indexJ,ref minValue))
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
               // PrintValueTable();
              //  Console.WriteLine();
            }
        }

        private static bool HasIndexMinValueTimeTable(ref int indexI, ref int indexJ,ref int minValue)
        {
            minValue = int.MaxValue;
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

      //  private static void PrintTableData()
      //  {
      //      var rowString = new List<string>();
      //
      //      Console.WriteLine("Xo   B1    B2    B3");
      //      for (int i = 0; i < table.GetLength(0); i++)
      //      {
      //          for (int j = 0; j < table.GetLength(1); j++)
      //          {
      //              var x = table[i, j]
      //                  .Select(x =>
      //                  (x.Key.ToString() + " " + x.Value.ToString()))
      //                  .ToArray()[0];
      //
      //              rowString.Add(x);
      //
      //
      //          }
      //          Console.Write($"A{++i}  ");
      //          Console.WriteLine(string.Join(", ", rowString));
      //          rowString.Clear();
      //      }
      //  }

        private static void FillTableWithData()
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                var row = Console.ReadLine()
                    .Split(", ")
                    .Select(x => new Dictionary<int, int>()
                               {
                                    { int.Parse(x.Split()[0]), int.Parse(x.Split()[1]) }
                               }).ToArray();

                for (int j = 0; j < table.GetLength(1); j++)
                {
                    table[i, j] = row[j];
                }

            }
        }
    }
}

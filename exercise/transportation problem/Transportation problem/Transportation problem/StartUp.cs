namespace Transportation_problem
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;

    class StartUp
    {
        private static int n, m;
        private static Dictionary<int, int>[,] table;
        static void Main()
        {
            Console.Write("Enter N= ");
            n = int.Parse(Console.ReadLine());
            Console.Write("Enter M= ");
            m = int.Parse(Console.ReadLine());
            table = new Dictionary<int, int>[n, m];
            FillTableWithData();

            PrintTableData();
        }

        private static void PrintTableData()
        {
            var rowString = new List<string>();
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    var x = table[i, j]
                        .Select(x => 
                        (x.Key.ToString() + " " + x.Value.ToString()))
                        .ToArray()[0];

                    rowString.Add(x);
                }
                Console.WriteLine(string.Join(", ",rowString));
                rowString.Clear();
            }
        }

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

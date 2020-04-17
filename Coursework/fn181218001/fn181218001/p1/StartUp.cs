namespace p1
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    class StartUp
    {
        private static List<int> sequence = new List<int>();
        private const int lengthOfSequence = 10;
        private const int start = 0;
        private const int end = 100;
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {

                    if (args.Length == 0)
                    {
                        args = Console.ReadLine().Split(" ");
                    }
                    switch (args[0])
                    {
                        case "-h":
                            Console.WriteLine(HelpCommand());
                            break;
                        case "-g":
                            Console.WriteLine(Gen());
                            Save(args[1]);
                            break;
                        case "-v":
                            Console.WriteLine(Load(args[1]));
                            break;
                        case "-s":
                            SortAndSaveToAnotherFile(args[1], args[2]);
                            Console.WriteLine("Successfully sorted and saved to another file!");
                            break;
                        case "-e":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid Command!");
                            Environment.Exit(0);
                            break;
                    }
                    args = Console.ReadLine().Split(" ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string HelpCommand()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"To generate random sequence of {lengthOfSequence} numbers (-g <file name>)");
            sb.AppendLine("To view values from file (-v <file name>)");
            sb.AppendLine("To read numbers from one file and save in another sorted (-s <file to read> <file to sort>)");
            sb.AppendLine("To exit (-e )");

            return sb.ToString().Trim();
        }

        public static string Gen()
        {
            Random rnd = new Random();
            sequence.Clear();

            for (int i = 0; i < lengthOfSequence; i++)
            {
                sequence.Add(rnd.Next(start, end));
            }

            return parseSequenceToString(sequence);
        }

        public static string Save(string fileName)
        {
            validateTxtFile(fileName);

            using (StreamWriter sw = new StreamWriter($@"D:\Programming\University\Coursework\fn181218001\{fileName}"))
            {
                sw.WriteLine(parseSequenceToString(sequence));
            }

            return "Successfully saved!";
        }

        public static string Load(string fileName)
        {
            validateTxtFile(fileName);

            var input = File.ReadAllLines(@$"D:\Programming\University\Coursework\fn181218001\{fileName}");
            sequence.Clear();

            //lines of .txt file
            for (int i = 0; i < input.Length; i++)
            {
                var nums = input[0].Split(", ").Select(int.Parse).ToArray();
                sequence.AddRange(nums);
            }

            return parseSequenceToString(sequence);
        }

        public static string View => parseSequenceToString(sequence);

        public static string Sort()
        {
            sequence.Sort();

            return parseSequenceToString(sequence);
        }

        public static void SortAndSaveToAnotherFile(string fileToRead, string fileToWrite)
        {
            Load(fileToRead);

            sequence.Sort();

            Save(fileToWrite);
        }

        private static void validateTxtFile(string fileName)
        {
            if (!(fileName.EndsWith(".txt") && fileName.Length > 4))
            {
                throw new Exception("Invalid file name");
            }
        }

        private static string parseSequenceToString(List<int> sequence) => string.Join(", ", sequence);
    }
}

namespace d1.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Controller
    {
        private readonly List<int> sequence;

        private const int lengthOfSequence = 10;
        private const int start = 0;
        private const int end = 100;
        public Controller()
        {
            sequence = new List<int>();
        }
        public string Gen()
        {
            Random rnd = new Random();
            sequence.Clear();

            for (int i = 0; i < lengthOfSequence; i++)
            {
                sequence.Add(rnd.Next(start, end));
            }

            return ParseSequenceToString(sequence);
        }

        public string Save(string fileName)
        {
            ValidateTxtFile(fileName);

            using (StreamWriter sw = new StreamWriter($@"D:\Programming\University\Coursework\fn181218001\{fileName}"))
            {
                sw.WriteLine(ParseSequenceToString(sequence));
            }

            return "Successfully saved!";
        }

        public string Load(string fileName)
        {
            ValidateTxtFile(fileName);

            var input = File.ReadAllLines($"D:\\Programming\\University\\Coursework\\fn181218001\\{fileName}");
            sequence.Clear();

            //lines of .txt file
            for (int i = 0; i < input.Length; i++)
            {
                var nums = input[0].Split(',').Select(x=>x.Trim()).Select(int.Parse).ToArray();
                sequence.AddRange(nums);
            }

            return ParseSequenceToString(sequence);
        }

        public string View => ParseSequenceToString(sequence);

        public string Sort()
        {
            sequence.Sort();

            return ParseSequenceToString(sequence);
        }

        public string SortAndSaveToAnotherFile(string fileToRead, string fileToWrite)
        {
            Load(fileToRead);

            sequence.Sort();

            Save(fileToWrite);

            return "New sorted file was created!";
        }

        private void ValidateTxtFile(string fileName)
        {
            if (!(fileName.EndsWith(".txt") && fileName.Length > 4&&!String.IsNullOrWhiteSpace(fileName)))
            {
                throw new Exception("Invalid file name");
            }
        }

        private string ParseSequenceToString(List<int> sequence) => string.Join(", ", sequence);

        public string HelpCommand()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"To generate random sequence of {lengthOfSequence} numbers (-g <file name>)");
            sb.AppendLine("To view values from file (-v <file name>)");
            sb.AppendLine("To read numbers from one file and save in another sorted (-s <file to read> <file to sort>)");
            sb.AppendLine("To exit (-e )");

            return sb.ToString().Trim();
        }
    }
}

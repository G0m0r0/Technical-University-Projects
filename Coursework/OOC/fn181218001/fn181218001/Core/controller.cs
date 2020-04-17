namespace fn181218001.Core
{
    using fn181218001.Core.Contracts;
    using fn181218001.Functionalities;
    using fn181218001.IO;
    using fn181218001.IO.Contracts;
    using fn181218001.Utilities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Controller:IController
    {
        private NumberGenerator numberGenerator;
        private List<int> sequence;
        public Controller()
        {
            this.numberGenerator = new NumberGenerator();
            this.sequence = new List<int>();
        }

        public string GenerateSubSequenceAndAddToSequence(int maxLengthSequence,int start,int end)
        {
            List<int> subSequence = this.numberGenerator.GenerateSubSequenceAndAddToSequence(maxLengthSequence,start,end);

            foreach (var num in subSequence)
            {
                this.sequence.Add(num);
            }

            return String.Format(OutputMessages.sequenceGenerated, 
                string.Join(", ",subSequence), string.Join(", ", sequence));
        }

        public string GenerateNumberAndAddToSequence(int start,int end)
        {
            int num = this.numberGenerator.GenerateNumberAndAddToSequence(start, end);
            sequence.Add(num);

            return String.Format(OutputMessages.numberGenerated, num, string.Join(", ", sequence));
        }

        public string Print()
        {
            string result = string.Empty;

            if (this.sequence.Count == 0)
            {
                result = "Sequence is empty!";
            }
            else
            {
                result = "Full sequence:\n" + string.Join(", ", sequence);
            }
             
            return result;
        }

        public string Sort()
        {
            sequence.Sort();

            return String.Format(OutputMessages.sort, string.Join(", ",sequence));
        }

        public void SaveOutputInFile()
        {
            IWriter write = new FileWriter();

            write.WriteLine(string.Join(", ", sequence));
        }

        public string Load()
        {
            var input = File.ReadAllLines(@"D:\Programming\University\Coursework\OOC\fn181218001\sequence.txt");

            //lines of txt file
            for (int i = 0; i < input.Length; i++)
            {
                var nums = input[0].Split(", ").Select(int.Parse).ToArray();
                this.sequence.AddRange(nums);
            
            }

            return string.Join(", ", sequence);
        }

        public string Save()
        {
            using (StreamWriter sequenceFile = new StreamWriter("D:\\Programming\\University\\Coursework\\OOC\\fn181218001\\sequence.txt"))
            {                
                    sequenceFile.WriteLine(string.Join(", ",this.sequence));
            }

            return OutputMessages.write;
        }

        public string Clear()
        {
            this.sequence.Clear();

            return OutputMessages.clear;
        }
    }
}

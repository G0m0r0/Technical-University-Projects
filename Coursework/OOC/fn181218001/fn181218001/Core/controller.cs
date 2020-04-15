namespace fn181218001.Core
{
    using fn181218001.Functionalities;
    using fn181218001.Utilities;
    using System;
    using System.Collections.Generic;

    public class controller
    {
        private NumberGenerator numberGenerator;
        private List<int> sequence;
        public controller()
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
    }
}

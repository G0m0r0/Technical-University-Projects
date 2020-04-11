namespace fn181218001.Core
{
    using fn181218001.Functionalities;
    using fn181218001.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Text;
   

    public class Controller
    {
        private NumberGenerator numberGenerator;
        public Controller(int start,int end)
        {
            this.numberGenerator = new NumberGenerator(start, end);
        }

        public string GenerateSequence(int maxLengthSequence)
        {
            List<int> sequence = this.numberGenerator.generateSequence(maxLengthSequence);

            return String.Format(OutputMessages.sequenceGenerated, string.Join(", ", sequence));
        }

        public string GenerateNumber()
        {
            int num = this.numberGenerator.generateNumber();

            return String.Format(OutputMessages.numberGenerated, num);
        }
    }
}

namespace fn181218001.Functionalities
{
    using fn181218001.Utilities;
    using System;
    using System.Collections.Generic;

    public class NumberGenerator
    {
        private int endValueOfNum;
        private int startValueOfNum;

        public NumberGenerator(int startValueOfNum,int endValueOfNum)
        {
            this.StartValueOfNum = startValueOfNum;
            this.EndValueOfNum = endValueOfNum;
        }
        public int StartValueOfNum
        {
            get => this.startValueOfNum;
            private set
            {
                if (value >= this.endValueOfNum)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.ImposibleRange,value,this.EndValueOfNum));
                }
                this.startValueOfNum = value;
            }
        }

        public int EndValueOfNum
        {
            get => this.endValueOfNum;
            private set
            {
                if (value <= this.StartValueOfNum)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.ImposibleRange, value, this.EndValueOfNum));
                }
                this.endValueOfNum = value;
            }
        }

        public List<int> generateSequence(int lengthOfSequence)
        {
            List<int> sequnceNum = new List<int>();
            Random rnd = new Random();

            if (lengthOfSequence <= 0)
            {
                throw new ArgumentException(ExceptionMessages.NegativeValue);
            }

            for (int i = 0; i < lengthOfSequence; i++)
            {
                sequnceNum.Add(rnd.Next(this.startValueOfNum, this.endValueOfNum));
            }

            return sequnceNum;
        }

        public int generateNumber()
        {
            Random rnd = new Random();

            return rnd.Next(this.startValueOfNum, this.endValueOfNum);
        }
    }
}

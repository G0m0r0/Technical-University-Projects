namespace fn181218001.Functionalities
{
    using fn181218001.Utilities;
    using System;
    using System.Collections.Generic;

    public class NumberGenerator
    { 
        public List<int> GenerateSubSequenceAndAddToSequence(int lengthOfSequence,int start,int end)
        {
            checkValues(start, end);

            List<int> sequnceNum = new List<int>();
            Random rnd = new Random();

            if (lengthOfSequence <= 0)
            {
                throw new ArgumentException(ExceptionMessages.NegativeValue);
            }

            for (int i = 0; i < lengthOfSequence; i++)
            {
                sequnceNum.Add(rnd.Next(start, end));
            }

            return sequnceNum;
        }

        public int GenerateNumberAndAddToSequence(int start,int end)
        {
            checkValues(start, end);

            Random rnd = new Random();

            return rnd.Next(start, end);
        }

        public void checkValues(int start,int end)
        {
            if (start >= end)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ImposibleRange, start, end));
            }
        }
    }
}

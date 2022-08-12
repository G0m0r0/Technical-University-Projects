using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @class
{
    class Program
    {
        class RationalNumber
        {
            private int numerator, denominator;
            public RationalNumber()
            {
                numerator = 0;
                denominator = 1;
            }
            public RationalNumber(int num, int denom)
            {
                numerator = num;
                denominator = denom;
            }
            public decimal ToDecimal()
            {
                return (decimal)numerator / denominator;
            }
            public override string ToString()
            {
                return string.Format("{0}/{1}", numerator, denominator);
            }
           // public RationalNumber Add(RationalNumber other) { /*…*/ } }

        static void Main(string[] args)
        {
                RationalNumber a = new RationalNumber(); //public RationalNumber()
                RationalNumber b = new RationalNumber(1, 4); // public RationalNumber(int num, int denom)
                RationalNumber c = null;
                Console.WriteLine("a= {0}, decimal: {1}", a, a.ToDecimal());
                Console.WriteLine("b= {0}, decimal: {1}", b, b.ToDecimal());
                if (c != null) //we cannot devide by 0
                    Console.WriteLine("c= {0}, decimal: {1}", c, c.ToDecimal()); //public decimal ToDecimal()
                //without override to string we dont get number in the output
            }
        }
    }
}

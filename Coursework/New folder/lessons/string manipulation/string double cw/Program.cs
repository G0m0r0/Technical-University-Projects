using System;

namespace string_double_cw
{
    class Program
    {
        static void Main(string[] args)
        {
            String.Format("{0:0.00}", 123.4567);      // "123.46"
            String.Format("{0:0.00}", 123.4);         // "123.40"
            String.Format("{0:0.00}", 123.0);         // "123.00"
        }
    }
}

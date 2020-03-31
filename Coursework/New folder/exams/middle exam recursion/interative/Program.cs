using System;

namespace interative
{
    class Program
    {
        static int interativ(int n)
        {
            int a = -1; //a1
            int b = 2; //a2
            int c = 3; //a3

            int num = 0;

            if (n == 1) return -1;
            else if (n == 2) return 2;
            else if (n == 3) return 3;

            for (int i = 4; i <= n; i++) //n=4 //n=7
            {
                num = c + 5 * b - 7 * a; //a4 //a7
                a = b; //a2 //a4
                b = c; //a3 //a5
                c = num; //a4 //a6
            }

            return num;
        }
       
        static void Main(string[] args)
        {
        }
    }
}

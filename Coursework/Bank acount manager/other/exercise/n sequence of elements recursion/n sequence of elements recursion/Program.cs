using System;

namespace n_sequence_of_elements_recursion
{
    class Program
    {
        static int Interativ(int n)
        {
            int a = 2;
            int b = 4;
            int c = 6;
            int element = 0;
            if (n > 3)
            {
                for (int i = 4; i <= n; i++)
                {
                    element = 3 * a + 4 * b - 7 * c;
                    a = b;
                    b = c;
                    c = element;
                }
                return element;
            }
            else if (n == 1) return 2;
            else if (n == 2) return 4;
            else if (n == 3) return 6;
            else return -1;
            
        }
        static int recursion(int n)
        {
            if (n == 1) return 2;
            else if (n == 2) return 4;
            else if (n == 3) return 6;
            return 3 * (recursion(n-3)) + 4 * (recursion(n-2)) -7*(recursion(n-1));
        }
        static void Main(string[] args)
        {
            Console.Write("Enter num of element that you want to get: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("number is "+Interativ(n));
            Console.WriteLine("number is "+recursion(n));
        }
    }
}

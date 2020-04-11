using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace double_mas_with_forfor
{
    class Program
    {
        static void Main(string[] args)
        {
            //TRIPAL MATRIX
            int[,,] matrix = new int[2, 3,2] { { {2,2}, { 1,1}, { 3,3} }, { { 4, 4}, { 5,5}, { 6 ,6} } };
            int a = matrix.Rank;
            Console.WriteLine(a);
            Console.WriteLine();
            foreach (int row in matrix)
            {
                Console.Write(row+" ");
                //Console.WriteLine();
            }
            
            Console.Read();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiplication_with_out
{
    class Program
    {
        static bool indexOfMinPositive(decimal[,] matrix,ref int minI,ref int MinJ)
        {
            decimal minPositive = decimal.MaxValue;
            bool flag = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i,j]>0)
                        if(matrix[i,j]<minPositive)
                        {
                            minPositive = matrix[i, j];
                            flag = true;
                            minI = i;
                            MinJ = j;
                        }   
                }
            }
            if(flag==false)
            {
                minI = -1;
                MinJ = -1;
                return false;
            }
            return true;         
        }
        static void Main(string[] args)
        {
            Console.WriteLine();
        }
     
    }
}

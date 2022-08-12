using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace try_catch
{
    class Program
    {
        //most common errors
        //1 syntactical error- syntax
        //2 compile time error- syntax and wrong data dypes
        //3 run time error
        static void processString(string s)
        {
            if(s==null)
            throw new ArgumentNullException();
        }
        static void Main(string[] args)
        {
            string s = null;
            try
           {
                processString(s);
           }
           catch(Exception e)
            {
                Console.WriteLine("{0} Exception caught.",e);
            }
        }
    }
}

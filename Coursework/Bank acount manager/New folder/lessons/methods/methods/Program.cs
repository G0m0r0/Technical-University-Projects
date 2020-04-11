using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methods
{
    //classes are structure of application
    class Program
    {
        //methods have to be in a class
        static void Main(string[] args)
        {
            person person = new person();
            var fullname=person.GetFullName("Delyan", "Dimitrov");
            Console.WriteLine(fullname);
        }
    }
}

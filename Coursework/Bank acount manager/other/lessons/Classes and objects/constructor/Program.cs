using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace constructor
{
    class Program
    {
        static void Main(string[] args)
        {
            //constructor overloading
            person person1 = new person("Delyan","Dimitrov");
            person person2 = new person("Delyan", 23);
            person person3 = new person("Delyan", "Dimitrov",25);

            //person p=new person(); //we cannot have default constructor
            Console.WriteLine(person1.GetFullNameWithAge());
            Console.WriteLine(person1.GetFullNameWithAge(27));

            Console.WriteLine(person2.GetFullNameWithAge());
            Console.WriteLine(person3.GetFullNameWithAge());

            

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace person_ref_method
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            person1.Firstname = "John";
            person1.Lastname = "Smith";

            changeName(person1);

            Console.WriteLine(person1.Firstname); //change the value by reference
            Console.WriteLine(person1.Lastname ); //change the value by reference
        }
        static void changeName(Person person)
        {
            person.Firstname = "Delyan";
            person.Lastname = "Dimitrov";
        }
    }
}

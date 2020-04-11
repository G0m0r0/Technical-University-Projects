using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace person_ref
{
    class Program
    {
        static void Main(string[] args)
        {
            person person1 = new person();

            person1.Firstname = "John";
            person1.Lastname = "Smith";

            person person2 = person1;
            person person3 = person2;
            person person4 = person3;
            person person5 = person4;

            person5.Firstname = "Jane"; //replace John in every person
            person5.Lastname = "Smithh"; //replave Smith in evry person
           

            Console.WriteLine(person1.Firstname);
            Console.WriteLine(person1.Lastname);

            Console.WriteLine(person2.Firstname);
            Console.WriteLine(person2.Lastname);

            Console.WriteLine(person3.Firstname);
            Console.WriteLine(person3.Lastname);
        }
    }
}

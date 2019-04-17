using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @static
{
    class person
    {
        public string firsName { get; set; }
        public string lastName { get; set; }
        public person(string firstName, string lastName)
        {
            this.firsName = firstName;
            this.lastName = lastName;
        }
        //insted of agrfirstname we use this only for non static
        public static string FormatFullName(string argfirstName, string argLastName)
        {
            return $"{argfirstName}- {argLastName}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            person person = new person("Delyan", "Dimitrov");
            Console.WriteLine(person.FormatFullName("Delyan", "Dimitrov")); 
        }
    }
}

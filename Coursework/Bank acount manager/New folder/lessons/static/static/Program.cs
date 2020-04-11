using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @static
{
    class person
    {
        //you can make static glasses objects methods its mean its belong to the class itself
        public string firsName { get; set; }
        public string lastName { get; set; }
        public person(string argfirstName, string arglastName)
        {
            firsName = argfirstName;
            lastName = arglastName;
            //initial the property values
        }
        public static string FormatFullName(string argfirstName,string argLastName)
        {
            return $"{argfirstName}- {argLastName}";
            //better to be non static
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            person person = new person("Delyan", "Dimitrov");
          Console.WriteLine(person.FormatFullName("Delyan", "Dimitrov")); //console is class writeline is static method
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace void_method
{
    class person
    {
        public void GetFullname(string firstName,string lastName)
        {
            Console.WriteLine($"The name of the person is {firstName} {lastName}");
        }
    }
}

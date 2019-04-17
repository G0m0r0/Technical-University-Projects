using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methods
{
    class person //internal class person internal specifier
    {
        public string GetFullName(string firstName,string lastName) //method signature
        {
            return $"The full name of the person is {firstName} {lastName}";
        }
    }
}

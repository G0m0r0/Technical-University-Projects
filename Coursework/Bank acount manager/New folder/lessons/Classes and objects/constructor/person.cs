using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace constructor
{
    class person
    {
        //overloading methods by (paramethers in the scope) //we can overload methods and constructors
        private string _firstName, 
                       _lastName;
        private int _age;
        public person(string firstName,int age) //constructors are special kind of methods
        {
            _firstName = firstName;
            _lastName = "Smith";
            _age = age;
        }
        public person(string firstName,string Lastname) //here by default //no return type
        {
            _firstName = firstName;
            _lastName = Lastname;
            _age = 25;
        }
        public person(string firstName, string Lastname,int age) 
        {
            _firstName = firstName;
            _lastName = Lastname;
            _age = age;
        }
        public string GetFullNameWithAge()
        {
            return $"{_firstName} {_lastName} {_age}";
        }
        public string GetFullNameWithAge(int age) //overlodding methods
        {
            return $"{_firstName} {_lastName} {age}";
        }
    }
}

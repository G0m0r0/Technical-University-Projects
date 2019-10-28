using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook
{
    [Serializable]
    class Person
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Person(string name,string phoneNum,string email)
        {
            this.Name = name;
            this.PhoneNumber = phoneNum;
            this.Email = email;
        }

        public override string ToString()
        {
            return $"Name: {this.Name},Phone: {this.PhoneNumber}, Email: {this.Email}.";
        }
    }
}

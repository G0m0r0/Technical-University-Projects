using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public List<string> PhoneNumber { get; set; }
        public List<string> Email { get; set; }

        public Person(string name):this()
        {
            this.Name = name;
        }
        public Person(string name, List<string> phoneNum, List<string> email):this(name)
        {
            this.PhoneNumber = phoneNum;
            this.Email = email;
        }
        public Person()
        {
            this.Name = string.Empty;
            this.PhoneNumber = new List<string>();
            this.Email = new List<string>();
        }

        public override string ToString()
        {
            return $"Name: {this.Name},Phone: {string.Join(" ", this.PhoneNumber)}, Email: {string.Join(" ", this.Email)}.";
        }
    }
}

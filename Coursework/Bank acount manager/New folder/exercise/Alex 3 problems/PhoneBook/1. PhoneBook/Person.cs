using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook
{
    [Serializable]
    public class Person
    {
        //public Person()
      //  {

      //  }
        //[System.Xml.Serialization.XmlElement("Name")]
        public string Name { get; set; }
       // [System.Xml.Serialization.XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; }
       // [System.Xml.Serialization.XmlElement("Email")]
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

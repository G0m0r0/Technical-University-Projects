namespace BankAccountManager.Models
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Security;

    public class Person : IPerson
    {
        private const int nameLenghtMax = 20;
        public Person(string firstName, string lastName, int age, SecureString id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Id = id;
        }

        private string firstName;
        private string lastName;
        private int age;
        SecureString id;

        public SecureString Id
        {
            get { return id; }
            private set 
            { 
                if(value.Length<0&&value.Length>10)
                {
                    throw new ArgumentException("Invalid ID!");
                }

                id = value; 
            }
        }

        public int Age
        {
            get { return age; }
            private set 
            {
                if (value < 0 && value > 120)
                {
                    throw new ArgumentException("Invalid age!");
                }
                age = value; 
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set 
            { 
                if(!ValidName(value))
                {
                    throw new ArgumentException("Inavalid first name!");
                }
                lastName = value; 
            }
        }

        public string FirstName
        {
            get { return firstName; }
            private set 
            {
                if (!ValidName(value))
                {
                    throw new ArgumentException("Inavalid last name!");
                }
                firstName = value; 
            }
        }

        private bool ValidName(string name)
        {
            if(name.Length<=0&&name.Length>nameLenghtMax)
            {
                return false;
            }

            return true;
        }
    }
}

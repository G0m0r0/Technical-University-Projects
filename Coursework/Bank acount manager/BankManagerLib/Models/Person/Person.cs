﻿namespace BankManagerLib.Models.Person
{
    using BankManagerLib.Models.Accounts.Contracts;
    using BankManagerLib.Models.Person.Contracts;
    using System;
    using System.Collections.Generic;
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
            this.accounts = new List<IAccount>();
        }

        private readonly List<IAccount> accounts;
        private string firstName;
        private string lastName;
        private int age;
        SecureString id;

        public SecureString Id
        {
            get { return id; }
            private set 
            {
                if (String.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentException("ID cannot be null or empty!");
                }

                if (value.Length<0&&value.Length>10)
                {
                    throw new ArgumentOutOfRangeException("Invalid ID!");
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
                    throw new ArgumentOutOfRangeException("Invalid age!");
                }
                age = value; 
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set 
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name cannot be null or empty!");
                }
                if (!ValidName(value))
                {
                    throw new ArgumentException("Inavalid last name!");
                }
                lastName = value; 
            }
        }

        public string FirstName
        {
            get { return firstName; }
            private set 
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name cannot be null or empty!");
                }
                if (!ValidName(value))
                {
                    throw new ArgumentException("Inavalid first name!");
                }
                firstName = value; 
            }
        }

        public string GetFullName => this.FirstName + " " + this.LastName;

        public ICollection<IAccount> Accounts => this.accounts;

        private bool ValidName(string name)
        {
            if(name.Length<=0&&name.Length>nameLenghtMax)
            {
                return false;
            }

            return true;
        }

        public void AddAccount(IAccount account)
        {
            if(account==null)
            {
                throw new ArgumentNullException("Account cannot be null!");
            }
            this.accounts.Add(account);
        }

        public bool RemoveAccount(IAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException("Account cannot be null!");
            }

            return this.accounts.Remove(account);
        }
    }
}

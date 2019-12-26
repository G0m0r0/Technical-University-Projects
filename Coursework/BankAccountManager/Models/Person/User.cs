namespace BankAccountManager.Models.Person
{
    using BankAccountManager.Models.Person.Contracts;
    using System;
    using System.Collections.Generic;
    public class User : IUser
    {
        public User()
        {
            this.users = new Dictionary<string, string>();
        }

        private string username;
        private string password;
        private Dictionary<string, string> users;

        public IDictionary<string, string> Users => this.users;

        public string Username
        {
            get { return username; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Username is empty!");
                }
                username = value;

            }
        }

        public string Password
        {
            get { return password; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Password is empty!");
                }
                password = value;
            }
        }

        public void addUser(string name, string password)
        {
            if (!this.users.ContainsKey(name))
            {
                this.users[name] = password;
            }
            else
            {
                throw new ArgumentException("User already exist!");
            }
        }

    }
}

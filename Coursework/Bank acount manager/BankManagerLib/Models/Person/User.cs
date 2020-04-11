namespace BankManagerLib.Models.Person
{
    using BankManagerLib.Models.Person.Contracts;
    using System;
    public class User : IUser
    {
        private const int lengthOfUsername = 15;
        private const int minLegnthOfPassword = 5;
        private const int maxLengthOfPassword = 15;
        public User(string username,string password)
        {
            this.Username = username;
            this.Password = password;
        }

        private string username;
        private string password;

        public string Username
        {
            get { return username; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name can not be empty!");
                }

                if (value.Length < 0 || value.Length > lengthOfUsername)
                {
                    throw new ArgumentException($"Name should be between 0 and {lengthOfUsername} symbols!");
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
                    throw new ArgumentNullException("Password can not be empty!");
                }

                if (value.Length < minLegnthOfPassword || value.Length > maxLengthOfPassword)
                {
                    throw new ArgumentException($"Password should be between {minLegnthOfPassword} and {maxLengthOfPassword}!");
                }
                password = value;
            }
        }

       // public void addUser(string name, string password)
       // {
       //     if (!this.users.ContainsKey(name))
       //     {
       //         this.users[name] = password;
       //     }
       //     else
       //     {
       //         throw new ArgumentException("User already exist!");
       //     }
       // }

    }
}

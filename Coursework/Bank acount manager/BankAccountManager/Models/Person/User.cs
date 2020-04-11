namespace BankAccountManager.Models.Person
{
    using BankAccountManager.Models.Person.Contracts;
    using System;
    using System.Runtime.Serialization;

    [Serializable()]
    public class User : IUser,ISerializable
    {
        private const int lengthOfUsername = 15;
        private const int minLegnthOfPassword = 5;
        private const int maxLengthOfPassword = 15;
        private IPerson person;
        public User(string username,string password)
        {
            this.Username = username;
            this.Password = password;
        }
        public User(SerializationInfo info,StreamingContext context)
        {
            this.Username = (string)info.GetValue("Username", typeof(string));
            this.Password = (string)info.GetValue("Password", typeof(string));
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
        public void addPersonTouser(IPerson personToAdd)
        {
            this.person = personToAdd;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Username", this.Username);
            info.AddValue("Password", this.Password);
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

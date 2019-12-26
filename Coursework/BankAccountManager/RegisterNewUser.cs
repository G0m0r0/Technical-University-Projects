namespace BankAccountManager
{
    using BankAccountManager.Models.Person;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class RegisterNewUser : Form
    {
        private const int lengthOfUsername = 15;
        private const int minLegnthOfPassword = 5;
        private const int maxLengthOfPassword = 15;

        private User userList;
        public RegisterNewUser()
        {
            InitializeComponent();
            this.userList = new User();
        }

        public IDictionary<string, string> UserList => this.userList.Users;

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var usernameInfo = string.Empty;
            var passwordInfo = string.Empty;

            try
            {
                if (ValidUsername(textBox1.Text))
                {
                    usernameInfo = textBox1.Text;
                }

                if(ValidPassword(textBox2.Text))
                {
                    passwordInfo = textBox2.Text;
                }

                userList.addUser(usernameInfo, passwordInfo);
                MessageBox.Show("Successfully added user!");

                textBox1.Clear();
                textBox2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private bool ValidPassword(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("Password can not be empty!");
            }

            if (text.Length < minLegnthOfPassword || text.Length>maxLengthOfPassword)
            {
                throw new ArgumentException($"Password should be between {minLegnthOfPassword} and {maxLengthOfPassword}!");
            }

            return true;
        }

        private bool ValidUsername(string text)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                throw new ArgumentNullException("Name can not be empty!");
            }

            if (text.Length < 0 || text.Length > lengthOfUsername)
            {
                throw new ArgumentException($"Name should be between 0 and {lengthOfUsername} symbols!");
            }

            return true;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

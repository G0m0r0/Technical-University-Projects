namespace BankAccountManager
{
    using BankAccountManager.Core.Contracts;
    using BankAccountManager.Models.Person;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class RegisterNewUser : Form
    {
        private IEngine Engin;
        private const char space = ' ';

        //private Dictionary<string,string> userList;
        public RegisterNewUser(IEngine engin)
        {
            InitializeComponent();
            //this.userList = new Dictionary<string, string>();
            this.Engin = engin;
        }

       // public IDictionary<string, string> UserList => this.userList;

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var username = textBox1.Text;
            var password = textBox2.Text;

            var command = "addUser" + space + username + space + password;
            Engin.Run(command);

            //userList.addUser(username, password);

            textBox1.Clear();
            textBox2.Clear();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

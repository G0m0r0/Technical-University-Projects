namespace BankAccountManager
{
    using System;
    using System.Windows.Forms;
    public partial class Login : Form
    {
        private RegisterNewUser registerForm;
        public Login()
        {
            InitializeComponent();
            registerForm = new RegisterNewUser();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();

            dialog = MessageBox.Show("Do you want to close?", "Alert!", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                Environment.Exit(1);
            }
        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            registerForm.Show();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Wallet wallet = new Wallet();
            //wallet.Show();
            //this.Hide(); 

            var userList = this.registerForm.UserList;
            var username = UserNameTextBox.Text;
            var password = PasswordTextBox.Text;

            try
            {
                CheckIfEmpty(username);
                CheckIfEmpty(password);

                if(userList.ContainsKey(username))
                {
                    if (password != userList[username])
                    {
                        MessageBox.Show("Wrong passowrd, try again!");
                    }
                    else
                    {
                        wallet.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Username with that name does not exist!");
                }

                PasswordTextBox.Clear(); 
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CheckIfEmpty(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Please enter correct information!");
            }
        }
    }
}

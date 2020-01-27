namespace BankAccountManager
{
    using BankAccountManager.Core.Contracts;
    using System;
    using System.Linq;
    using System.Windows.Forms;
    public partial class Login : Form
    {
        private RegisterNewUser registerForm;
        private IEngine Engin;
        public Login(IEngine engin)
        {
            InitializeComponent();
            this.Engin = engin;
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
            registerForm = new RegisterNewUser(Engin);
            registerForm.Show();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Wallet wallet = new Wallet(this.Engin);
            wallet.Show();
            this.Hide(); 

        //  var userList = Engin.GetAllUsers();
        //
        //  var username = UserNameTextBox.Text;
        //  var password = PasswordTextBox.Text;
        //
        //  var account = userList.SingleOrDefault(acc => acc.Username == username);
        //
        //  if (account == null)
        //  {
        //      throw new ArgumentException("User does not exist!");
        //  }
        //
        //  if (account.Password != password)
        //  {
        //      throw new ArgumentException("Wrong password, try again!");
        //  }
        //
        //  Wallet wallet = new Wallet(this.Engin);
        //  wallet.Show();
        //  this.Hide();
        }
    }
}

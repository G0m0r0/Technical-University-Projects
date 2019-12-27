namespace BankAccountManager
{
    using BankAccountManager.Core;
    using BankAccountManager.Core.Contracts;
    using System;
    using System.Security;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Linq;

    public partial class Wallet : Form
    {
        private const char space = ' ';
        private AddAccount addAccountForm;
        private IEngineWF engine;
        public Wallet()
        {
            InitializeComponent();
            this.engine = new Engine();
            this.addAccountForm = new AddAccount(engine);
        }

        private void Wallet_Load(object sender, EventArgs e)
        {

        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            var accountsList = engine.GetAllAccounts();

            foreach (var account in accountsList)
            {
                comboBox1.Items.Add(account);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();

            dialog = MessageBox.Show("Do you want to close?", "Alert!", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                Environment.Exit(1);
            }
        }

        private void AddAccountButton_Click(object sender, EventArgs e)
        {
            addAccountForm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var iban = comboBox1.SelectedItem.ToString().Split("___", StringSplitOptions.RemoveEmptyEntries)[1].Remove(0,4);
            IbanLabel.Text = iban;

            DepositButton.Enabled = true;
            WithdrawButton.Enabled = true;
            AllMoneyButton.Enabled = true;

            BalanceTextBox.Text= comboBox1.SelectedItem.ToString().Split("___", StringSplitOptions.RemoveEmptyEntries)[2];
        }

        private void DepositButton_Click(object sender, EventArgs e)
        {
            var iban = IbanLabel.Text;

            string command = $"deposit {AmounthTextBox.Text} {iban}";

            engine.Run(command);

            decimal newBalance = decimal.Parse(BalanceTextBox.Text.Remove(BalanceTextBox.Text.Length - 1, 1)) + decimal.Parse(AmounthTextBox.Text);
            BalanceTextBox.Text = newBalance.ToString()+"$";

            AmounthTextBox.Clear();
        }
    }
}

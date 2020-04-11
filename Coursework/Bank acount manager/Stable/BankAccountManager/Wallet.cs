namespace BankAccountManager
{
    using BankAccountManager.Core.Contracts;
    using System;
    using System.Security;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Linq;
    using System.Collections.Generic;

    public partial class Wallet : Form
    {
        private AddAccount addAccountForm;
        private Transactions transactions;
        private readonly IEngine Engine;
        private System.Timers.Timer myTimer;
        private int hours=0, minutes=0, seconds=0;

        public Wallet(IEngine engin)
        {
            InitializeComponent();
            this.Engine = engin;
            this.addAccountForm = new AddAccount(Engine);
        }

        private void Wallet_Load(object sender, EventArgs e)
        {
            this.myTimer = new System.Timers.Timer();
            this.myTimer.Interval = 1000; //1s
            this.myTimer.Elapsed += OnTimeEven;
        }

        private void OnTimeEven(object sender, System.Timers.ElapsedEventArgs e)
        {
            var listOfInterestForDay = new List<decimal>();
            Invoke(new Action(() =>
            {
                seconds++;
                if (seconds == 60)
                {
                    seconds = 0;
                    minutes++;
                }
                if (minutes == 60)
                {
                    minutes = 0;
                    hours++;
                }
                if (hours == 24)
                {
                    hours = 0;
                    Engine.Run("addinterest");
                }

                textBox1.Text = string.Format($"{hours.ToString().PadLeft(2, '0')}:{minutes.ToString().PadLeft(2, '0')}:{seconds.ToString().PadLeft(2, '0')}");
            }));
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            var accountsList = Engine.GetAllAccounts();

            if (textBox1.Text == "00:00:00"&&accountsList.Count>0)
                myTimer.Start();

            foreach (var account in accountsList)
            {
                comboBox1.Items.Add(account);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to close?", "Alert!", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                Environment.Exit(1);
            }
        }

        private void AddAccountButton_Click(object sender, EventArgs e)
        {            
            addAccountForm.Show();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var iban = comboBox1.SelectedItem.ToString().Split("___", StringSplitOptions.RemoveEmptyEntries)[1].Remove(0, 4);
            IbanLabel.Text = iban;

            DepositButton.Enabled = true;
            WithdrawButton.Enabled = true;
            AllMoneyButton.Enabled = true;

            BalanceTextBox.Text = comboBox1.SelectedItem.ToString().Split("___", StringSplitOptions.RemoveEmptyEntries)[2];
        }

        private void DepositButton_Click(object sender, EventArgs e)
        {
            var iban = IbanLabel.Text;

            string command = $"deposit {AmounthTextBox.Text} {iban}";

            Engine.Run(command);

            var account = Engine.GetAllAccounts().FirstOrDefault(x => DecriptSecureString(x.Iban) == iban);
            BalanceTextBox.Text = account.GetBalance.ToString() + '$';

            AmounthTextBox.Clear();
        }

        private void WithdrawButton_Click(object sender, EventArgs e)
        {
            var iban = IbanLabel.Text;

            string command = $"withdraw {AmounthTextBox.Text} {iban}";

            Engine.Run(command);

            var account = Engine.GetAllAccounts().FirstOrDefault(x => DecriptSecureString(x.Iban) == iban);
            BalanceTextBox.Text = account.GetBalance.ToString() + '$';

            AmounthTextBox.Clear();
        }
        private string DecriptSecureString(SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

        private void AllMoneyButton_Click(object sender, EventArgs e)
        {
            var command = "balanceofallaccounts";
            Engine.Run(command);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.transactions = new Transactions(Engine);
            transactions.Show();
        }
    }
}

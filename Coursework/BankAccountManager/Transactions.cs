namespace BankAccountManager
{
    using BankAccountManager.Core.Contracts;
    using BankAccountManager.Models.Accounts.Contracts;
    using BankAccountManager.Models.Enums;
    using BankAccountManager.Models.Transactions.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Text;
    using System.Transactions;
    using System.Windows.Forms;

    public partial class Transactions : Form
    {
        private readonly IEngineWF Engin;
        private readonly Dictionary<SecureString, IReadOnlyCollection<ITransaction>> transactionDictionary;
        public Transactions(IEngineWF engin)
        {
            InitializeComponent();
            this.Engin = engin;
            this.transactionDictionary = new Dictionary<SecureString, IReadOnlyCollection<ITransaction>>();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                //number
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                //date
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                //type-withdraw
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                //type-deposit
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                //amounth-withdraw
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                //amounth-deposit
            }
        }

        private void Transactions_Load(object sender, EventArgs e)
        {
            IReadOnlyCollection<IAccount> listAccounts = Engin.GetAllAccounts();
            //load in constructor ?

            foreach (var account in listAccounts)
            {
                var iban = account.Iban;
                if(!this.transactionDictionary.ContainsKey(iban))
                {
                    this.transactionDictionary[iban] = account.Transactions;
                }
            }
            int number = 1;
            foreach (var kvp in transactionDictionary)
            {                
                foreach (var transaction in kvp.Value)
                {
                    ListViewItem lvi = new ListViewItem(number.ToString());

                    lvi.SubItems.Add(DecriptSecureString(kvp.Key));
                    lvi.SubItems.Add(string.Format("{0:MM/dd/yyyy hh:mm tt}", transaction.DateTime));
                    lvi.SubItems.Add(transaction.TypeTransaction.ToString());
                    lvi.SubItems.Add(transaction.Amount.ToString());

                    ListTransactions.Items.Add(lvi);
                    number++;
                }

                foreach (ListViewItem row in ListTransactions.Items)
                {
                    if (row.SubItems["Type"].ToString() == "Withdraw")
                    {
                        row.BackColor = Color.LightCoral;
                    }
                    else if(row.SubItems["Type"].ToString()=="Deposit")
                    {
                        row.BackColor = Color.LightBlue;
                    }
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to close?", "Alert!", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                Environment.Exit(1);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
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
    }
}

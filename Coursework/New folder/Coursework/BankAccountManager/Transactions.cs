namespace BankAccountManager
{
    using BankAccountManager.Core.Contracts;
    using BankAccountManager.Models.Accounts.Contracts;
    using BankAccountManager.Models.Transactions.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Windows.Forms;

    public partial class Transactions : Form
    {
        private readonly IEngine Engin;
        private readonly Dictionary<SecureString, IList<ITransaction>> transactionDictionary;
        public Transactions(IEngine engin)
        {
            InitializeComponent();
            this.Engin = engin;
            this.transactionDictionary = new Dictionary<SecureString, IList<ITransaction>>();
        }

        private void Transactions_Load(object sender, EventArgs e)
        {
            IReadOnlyCollection<IAccount> listAccounts = Engin.GetAllAccounts();
            //load in constructor ?

            foreach (var account in listAccounts)
            {
                var iban = account.Iban;
                if (!this.transactionDictionary.ContainsKey(iban))
                {
                    this.transactionDictionary[iban] = account.Transactions;
                }
            }
            int number = 1;
            foreach (var kvp in transactionDictionary)
            {
                foreach (var transaction in kvp.Value)
                {
                    CreateListView(transaction, ref number, kvp.Key);
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

        private void CreateListView(ITransaction transaction, ref int number, SecureString key)
        {
            ListViewItem lvi = new ListViewItem(number.ToString());

            lvi.SubItems.Add(DecriptSecureString(key));
            lvi.SubItems.Add(string.Format("{0:MM/dd/yyyy hh:mm tt}", transaction.DateTime));
            lvi.SubItems.Add(transaction.TypeTransaction.ToString());
            lvi.SubItems.Add(transaction.Amount.ToString());

            ListTransactions.Items.Add(lvi);
            number++;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int number = 1;
            for (int i = 0; i < ListTransactions.Items.Count; i++)
            {
                ListTransactions.Items.RemoveAt(i--);
            }

            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Enabled = false;
                textBox1.Clear();

                foreach (var kvp in transactionDictionary)
                {
                    foreach (var transaction in kvp.Value.OrderBy(x => x.DateTime))
                    {
                        CreateListView(transaction, ref number, kvp.Key);
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                textBox1.Enabled = false;
                textBox1.Clear();

                foreach (var kvp in transactionDictionary)
                {
                    foreach (var transaction in kvp.Value.Where(x => x.TypeTransaction.ToString() == "Withdraw"))
                    {
                        CreateListView(transaction, ref number, kvp.Key);
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                textBox1.Enabled = false;
                textBox1.Clear();

                foreach (var kvp in transactionDictionary)
                {
                    foreach (var transaction in kvp.Value.Where(x => x.TypeTransaction.ToString() == "Deposit"))
                    {
                        CreateListView(transaction, ref number, kvp.Key);
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                textBox1.Enabled = false;
                textBox1.Clear();

                foreach (var kvp in transactionDictionary)
                {
                    foreach (var transaction in kvp.Value
                        .Where(x => x.TypeTransaction.ToString() == "Withdraw")
                        .OrderBy(x => x.Amount))
                    {
                        CreateListView(transaction, ref number, kvp.Key);
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                textBox1.Enabled = false;
                textBox1.Clear();

                foreach (var kvp in transactionDictionary)
                {
                    foreach (var transaction in kvp.Value
                        .Where(x => x.TypeTransaction.ToString() == "Deposit")
                        .OrderBy(x => x.Amount))
                    {
                        CreateListView(transaction, ref number, kvp.Key);
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                textBox1.Enabled = true;

                foreach (var kvp in transactionDictionary)
                {
                    if (DecriptSecureString(kvp.Key) == textBox1.Text)
                        foreach (var transaction in kvp.Value)
                        {
                            CreateListView(transaction, ref number, kvp.Key);
                        }
                }
            }
        }
    }
}

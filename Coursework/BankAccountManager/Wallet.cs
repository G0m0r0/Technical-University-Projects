using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BankAccountManager
{
    public partial class Wallet : Form
    {
        private AddAccount addAccountForm;
        private string personInfo;
        private List<string> accountsList;
        public Wallet()
        {
            InitializeComponent();
            addAccountForm = new AddAccount();
        }

        private void Wallet_Load(object sender, EventArgs e)
        {

        }

        private void RecentTransactionButton_Click(object sender, EventArgs e)
        {
           //this.personInfo = addAccountForm.PersonInfo;
           //this.accountsList = addAccountForm.AccountsInfo;

            foreach (var account in accountsList)
            {
                var typeAccount = account.ToArray()[0];
                var iban = string.Join(" ", account.Split().TakeLast(1));
                string comboBoxDisplayLine = typeAccount + " " + iban;
                comboBox1.Items.Add(comboBoxDisplayLine);
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
    }
}

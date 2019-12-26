using BankAccountManager.Core;
using BankAccountManager.Core.Contracts;
using BankAccountManager.Models.Accounts;
using BankAccountManager.Models.Accounts.Contracts;
using BankAccountManager.Models.Person;
using BankAccountManager.Models.Person.Contracts;
using BankAccountManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Windows.Forms;

namespace BankAccountManager
{
    public partial class AddAccount : Form
    {
        private const char space = ' ';
        IController controller;

        public AddAccount()
        {
            InitializeComponent();

            this.controller = new Controller();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddAccount_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var personId = new SecureString();
            try
            {
                var fullName = textBox1.Text.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var firstName = string.Empty;
                var lastName = string.Empty;
                if (fullName.Length != 3)
                {
                    throw new ArgumentException("Please enter full name!");
                }
                else
                {
                    firstName = fullName[0];
                    lastName = fullName[2];
                }
                if (string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    throw new ArgumentNullException("Age can not be empty!");
                }
                var age = int.Parse(textBox5.Text);
                if (string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    throw new ArgumentNullException("Person ID can not be empty!");
                }
                personId = MakeStringSecureString(textBox4.Text);


                controller.AddPerson(firstName, lastName, age, personId);               

                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox6.Enabled = true;
                button4.Enabled = true;

                textBox1.Enabled = false;
                textBox5.Enabled = false;
                textBox4.Enabled = false;
                button1.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                personId.Dispose();
            }

        }

        private void AddAccount_Load_1(object sender, EventArgs e)
        {

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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var personIdToaddAccount = new SecureString();
            var iban = new SecureString();
            try
            {
                var accountType = string.Empty;
                if (radioButton1.Checked)
                {
                    accountType = "CheckingAccount";
                }
                else if (radioButton2.Checked)
                {
                    accountType = "ChildSavingsAccount";
                }
                else if (radioButton3.Checked)
                {
                    accountType = "RetirmentAccount";
                }

                personIdToaddAccount = this.controller.Person.Id;

                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    throw new ArgumentNullException("Balance can not be empty!");
                }
                var balance = decimal.Parse(textBox2.Text);

                if (string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    throw new ArgumentNullException("Interest rate can not be empty!");
                }
                var interestRate =float.Parse( textBox6.Text);

                if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    throw new ArgumentNullException("IBAN can not be empty!");
                }
                iban = MakeStringSecureString(textBox3.Text);

                controller.AddAccount(accountType, personIdToaddAccount, balance, interestRate, iban);

                textBox2.Clear();
                textBox3.Clear();
                textBox6.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                personIdToaddAccount.Dispose();
                iban.Dispose();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox5.Enabled = true;
            textBox4.Enabled = true;
            button1.Enabled = true;

            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox6.Enabled = false;
            button4.Enabled = false;
        }
        private SecureString MakeStringSecureString(string str)
        {
            using (var secureString = new SecureString())
            {
                foreach (var chr in str.ToCharArray())
                {
                    secureString.AppendChar(chr);
                }

                return secureString;
            }
            //dispose with using
        }
    }
}

namespace BankAccountManager
{
    using BankAccountManager.Core.Contracts;
    using System;
    using System.Linq;
    using System.Windows.Forms;
    public partial class AddAccount : Form
    {
        private const char space = ' ';
        private readonly IEngine Engine;
        public AddAccount(IEngine engine)
        {
            InitializeComponent();

            this.Engine = engine;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            var fullName = textBox1.Text.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string firstName;
            string lastName;
            if (fullName.Length != 3)
            {
                throw new ArgumentException("Please enter full name!");
            }
            else
            {
                firstName = fullName[0];
                lastName = fullName[2];
            }
            var age = textBox5.Text;
            var personId = textBox4.Text;

            string command = "addperson" + space + firstName + space + lastName + space + age + space + personId;
            this.Engine.Run(command);

            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox6.Enabled = true;
            button4.Enabled = true;

            textBox1.Enabled = false;
            textBox5.Enabled = false;
            textBox4.Enabled = false;
            button1.Enabled = false;

        }

        private void AddAccount_Load_1(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var iban = textBox8.Text;
            var amount = textBox9.Text;

            string operationOverdraft = string.Empty;
            if(checkBox1.Checked)
            {
                operationOverdraft = "activateoverdraft";
            }
            else if(checkBox2.Checked)
            {
                operationOverdraft = "deactivateoverdraft";
                textBox8.Enabled = false;
            }

            string command = operationOverdraft + space + iban + space + amount;
            this.Engine.Run(command.TrimEnd());

            textBox8.Clear();
            textBox9.Clear();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
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

            var personIdToaddAccount = textBox4.Text;
            var balance = textBox2.Text;
            var interestRate = textBox6.Text;
            var iban = textBox3.Text;

            string command ="addaccount"+space+ accountType + space + personIdToaddAccount + space + balance + space + interestRate + space + iban;
            this.Engine.Run(command.TrimEnd());

            textBox2.Clear();
            textBox3.Clear();
            textBox6.Clear();
        }

        private void Button5_Click(object sender, EventArgs e)
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;

            textBox8.Enabled = true;
            textBox9.Enabled = true;

            button2.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox9.Enabled = false;
            textBox9.Clear();

            textBox8.Enabled = false;
            textBox8.Clear();

            checkBox1.Enabled = false;
            checkBox2.Enabled = false;

            button2.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox9.Enabled = false;
            textBox9.Clear();

            textBox8.Enabled = false;
            textBox8.Clear();

            checkBox1.Enabled = false;
            checkBox2.Enabled = false;

            button2.Enabled = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBox9.Enabled = false;
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox9.Enabled = true;

        }
    }
}

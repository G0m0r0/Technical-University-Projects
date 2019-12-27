namespace BankAccountManager
{
    using BankAccountManager.Core.Contracts;
    using System;
    using System.Linq;
    using System.Windows.Forms;
    public partial class AddAccount : Form
    {
        private const char space = ' ';
        private IEngineWF Engine;
        public AddAccount(IEngineWF engine)
        {
            InitializeComponent();

            this.Engine = engine;
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
            this.Engine.Run(command);

            textBox2.Clear();
            textBox3.Clear();
            textBox6.Clear();
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
    }
}

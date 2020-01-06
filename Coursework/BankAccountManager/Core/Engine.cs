namespace BankAccountManager.Core
{
    using BankAccountManager.Core.Contracts;
    using BankAccountManager.IO;
    using BankAccountManager.IO.Contracts;
    using BankAccountManager.Models.Accounts.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Security;

    public class Engine : IEngineWF
    {
        //private IWriter writer;
        //private IReader reader;
        private IWFMessageBox messagebox;
        private IController controller;

        public Engine()
        {
            //this.writer = new Writer();
            // this.reader = new Reader();
            this.messagebox = new WFMessageBox();
            this.controller = new Controller();
        }
        public void Run(string input)
        {
            //while (true)
            // {
            if (input == "Exist")
            {
                Environment.Exit(1);
            }
            var tokens = input.Split(new char[] { ' ', ',', '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

            string resultMessage = string.Empty;
            string command = tokens[0];
            try
            {
                switch (command.ToLower())
                {
                    case "addaccount":
                        string accountType = tokens[1];
                        var personIdToaddAccount = MakeStringSecureString(tokens[2]);
                        var balance = decimal.Parse(tokens[3]);
                        var interestRate = float.Parse(tokens[4]);
                        var iban = MakeStringSecureString(tokens[5]);

                        resultMessage = controller.AddAccount(accountType, personIdToaddAccount, balance, interestRate, iban);
                        break;
                    case "addperson":
                        var firstName = tokens[1];
                        var lastName = tokens[2];
                        var age = int.Parse(tokens[3]);
                        var personId = MakeStringSecureString(tokens[4]);

                        resultMessage = controller.AddPerson(firstName, lastName, age, personId);
                        break;
                    case "balanceofallaccounts":
                        resultMessage = controller.CalculateAllMoney();
                        break;
                    case "deposit":                       
                        var moneyTodeposit = decimal.Parse(tokens[1]);
                        var ibanToAddMoney = MakeStringSecureString(tokens[2]);

                        resultMessage = controller.Deposit(moneyTodeposit, ibanToAddMoney);
                        break;
                    case "withdraw":
                        var moneyTowithDraw = decimal.Parse(tokens[1]);
                        var ibanToWithdrawMoney = MakeStringSecureString(tokens[2]);

                        resultMessage = controller.Withdraw( moneyTowithDraw, ibanToWithdrawMoney);
                        break;
                    case "report":
                        var personIDToGetInfo = MakeStringSecureString(tokens[1]);

                        resultMessage = controller.Report(personIDToGetInfo);
                        break;
                    default:
                        throw new ArgumentException($"Command of type {command} does not exist!");
                }
            }
            catch (Exception ex)
            {
                //writer.WriteLine(ex.Message);
                resultMessage = ex.Message;
            }
            finally
            {
                this.messagebox.Show(resultMessage);
            }

            //writer.WriteLine(resultMessage);
            // }
        }

        public IReadOnlyCollection<IAccount> GetAllAccounts() => this.controller.TakeAllAccounts();

        private SecureString MakeStringSecureString(string str)
        {
            // using (var secureString = new SecureString())
            //{
            var secureString = new SecureString();
                foreach (var chr in str.ToCharArray())
                {
                    secureString.AppendChar(chr);
                }

                return secureString;
            //}
        //
        }
    }
}

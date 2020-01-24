namespace BankAccountManager.Core
{
    using BankAccountManager.Core.Contracts;
    using BankAccountManager.IO;
    using BankAccountManager.IO.Contracts;
    using BankAccountManager.Models.Accounts.Contracts;
    using BankAccountManager.Models.Person.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Security;

    public class Engine : IEngine
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

            string resultMessage = string.Empty;
            try
            {
                var tokens = input.Split(new char[] { ' ', ',', '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                switch (command.ToLower())
                {
                    case "addaccount":
                        CheckCorrectInformation(6, tokens.Length);

                        string accountType = tokens[1];
                        var personIdToaddAccount = MakeStringSecureString(tokens[2]);
                        var balance = decimal.Parse(tokens[3]);
                        var interestRate = float.Parse(tokens[4]);
                        var iban = MakeStringSecureString(tokens[5]);

                        resultMessage = controller.AddAccount(accountType, personIdToaddAccount, balance, interestRate, iban);
                        break;
                    case "addperson":
                        CheckCorrectInformation(5, tokens.Length);

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
                        CheckCorrectInformation(3, tokens.Length);

                        var moneyTodeposit = decimal.Parse(tokens[1]);
                        iban = MakeStringSecureString(tokens[2]);

                        resultMessage = controller.Deposit(moneyTodeposit, iban);
                        break;
                    case "withdraw":
                        CheckCorrectInformation(3, tokens.Length);

                        var moneyTowithDraw = decimal.Parse(tokens[1]);
                        iban = MakeStringSecureString(tokens[2]);

                        resultMessage = controller.Withdraw(moneyTowithDraw, iban);
                        break;
                    case "report":
                        CheckCorrectInformation(2, tokens.Length);

                        var personIDToGetInfo = MakeStringSecureString(tokens[1]);

                        resultMessage = controller.Report(personIDToGetInfo);
                        break;
                    case "activateoverdraft":
                        CheckCorrectInformation(3, tokens.Length);

                        iban = MakeStringSecureString(tokens[1]);
                        var amounthForOverdraft = decimal.Parse(tokens[2]);

                        resultMessage = controller.ActivateOverdraft(iban, amounthForOverdraft);
                        break;
                    case "deactivateoverdraft":
                        CheckCorrectInformation(2, tokens.Length);

                        iban = MakeStringSecureString(tokens[1]);

                        resultMessage = controller.DeactivateOverdraft(iban);
                        break;
                    case "adduser":
                        CheckCorrectInformation(3, tokens.Length);

                        string username = tokens[1];
                        string password = tokens[2];

                        resultMessage = controller.CreateNewUser(username, password);
                        break;
                    case "login":
                        CheckCorrectInformation(3, tokens.Length);

                        username = tokens[1];
                        password = tokens[2];

                        //resultMessage=
                        break;
                    case "addinterest":
                        controller.AddInterestToAllAccounts();
                        break;
                    default:
                        throw new ArgumentException($"Command does not exist!");
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

        private void CheckCorrectInformation(int numOfNeededOperations, int operations)
        {
            if (numOfNeededOperations != operations)
            {
                throw new ArgumentNullException("Not enough information!");
            }
        }

        public IReadOnlyCollection<IAccount> GetAllAccounts() => this.controller.TakeAllAccounts();
        public IReadOnlyCollection<IUser> GetAllUsers() => this.controller.TakeAllUsers();

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

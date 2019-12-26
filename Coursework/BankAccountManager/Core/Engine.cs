namespace BankAccountManager.Core
{
    using BankAccountManager.Core.Contracts;
    using BankAccountManager.IO;
    using BankAccountManager.IO.Contracts;
    using System;
    using System.Security;

    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }
        public void Run()
        {
            string input = string.Empty;
            while ((input=reader.ReadLine())!="Exit")
            {
                var tokens = input.Split(new char[] {' ',',','\r','\n'}, System.StringSplitOptions.RemoveEmptyEntries);

                string resultMessage = string.Empty;
                string command = tokens[0];
                try
                {                    
                    switch (command.ToLower())
                    {
                        case "add account":
                            string accountType = tokens[1];
                            var personIdToaddAccount= MakeStringSecureString(tokens[2]);
                            var balance = decimal.Parse(tokens[3]);
                            var interestRate = float.Parse(tokens[4]);
                            var iban = MakeStringSecureString(tokens[5]);

                            resultMessage = controller.AddAccount(accountType, personIdToaddAccount, balance, interestRate, iban);
                            break;
                        case "add person":
                            var firstName = tokens[1];
                            var lastName = tokens[2];
                            var age = int.Parse(tokens[3]);
                            var personId = MakeStringSecureString(tokens[4]);

                            resultMessage = controller.AddPerson(firstName, lastName, age, personId);
                            break;
                        case "balance of all accounts":
                            var personIdToTakeBalance = MakeStringSecureString(tokens[1]);

                            resultMessage = controller.CalculateAllMoney(personIdToTakeBalance);
                            break;
                        case "deposit":
                            var personIdToAddMoney = MakeStringSecureString(tokens[1]);
                            var moneyTodeposit = decimal.Parse(tokens[2]);
                            var ibanToAddMoney = MakeStringSecureString(tokens[3]);

                            resultMessage = controller.Deposit(personIdToAddMoney, moneyTodeposit, ibanToAddMoney);
                            break;
                        case "withdraw":
                            var personToWithdrawMoney = MakeStringSecureString(tokens[1]);
                            var moneyTowithDraw = decimal.Parse(tokens[2]);
                            var ibanToWithdrawMoney = MakeStringSecureString(tokens[3]);

                            resultMessage = controller.Withdraw(personToWithdrawMoney,moneyTowithDraw,ibanToWithdrawMoney);
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
                    writer.WriteLine(ex.Message);
                }

                writer.WriteLine(resultMessage);
            }
        }

        private SecureString MakeStringSecureString(string str)
        {
            using (var secureString=new SecureString())
            {
                foreach (var chr in str.ToCharArray())
                {
                    secureString.AppendChar(chr);
                }

               return secureString;
            }
            
        }
    }
}

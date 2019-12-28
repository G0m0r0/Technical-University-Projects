﻿namespace BankAccountManager.Core
{
    using System.Collections.Generic;
    using System.Security;
    using System;
    using BankAccountManager.Core.Contracts;
    using BankAccountManager.Models.Accounts.Contracts;
    using BankAccountManager.Models.Person.Contracts;
    using BankAccountManager.Repositories;
    using BankAccountManager.Repositories.Contracts;
    using BankAccountManager.Models.Person;
    using BankAccountManager.Models.Accounts;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;

    public class Controller : IController
    {
        private const string SepratorOfAccounts = "-------------------";

        public Controller()
        {
            this.person = null;
            this.accountRepository = new AccountRepository();
        }

        //private List<IPerson> persons;
        private IPerson person;
        private IRepository<IAccount> accountRepository;

       // public IPerson Person => this.person;
       // public IRepository<IAccount> Account => this.accountRepository;

        public string AddAccount(string accountType,SecureString idPerson, decimal balance, float interestRate, SecureString Iban)
        {
            IAccount account = null;
            if(this.accountRepository.FindByIdentification(Iban))
            {
                throw new Exception("Iban already exist!");
            }
            //IPerson person = CheckIfPersonExistByID(idPerson);
            accountType = accountType.ToLower();

            if(accountType=="checkingaccount")
            {
                account = new CheckingAccount(this.person, balance, interestRate, Iban);
            }
            else if(accountType== "childsavingsaccount")
            {
                account = new ChildSavingsAccount(this.person, balance, interestRate, Iban);
            }
            else if(accountType=="retirmentaccount")
            {
                account = new RetirmentAccount(this.person, balance, interestRate, Iban);
            }
            else
            {
                throw new ArgumentException("Account type is not valid");
            }

            this.accountRepository.Add(account);

            return $"Successfully added {accountType}.";
        }

        public string AddPerson(string firstName, string lastName, int age, SecureString ID)
        {
            this.person= new Person(firstName, lastName, age, ID);
            //this.persons.Add(person);

            return "Seccessfully added person!";
        }

        public string CalculateAllMoney()
        {
            var sum = accountRepository.Models.Sum(x => x.GetBalance);

            return $"Money available in all accounts {sum:F2}.";
        }

        public string Deposit(decimal amount,SecureString iban)
        {
            IAccount accountToDepositMoney = checkIfAccountExistByIban(iban);

            if(accountToDepositMoney==null)
            {
                throw new ArgumentNullException($"Account does not exist");
            }

            accountToDepositMoney.Deposit(amount);

            return $"Seccessfully deposited {amount}$ to your account.";
        }
        public string Withdraw(decimal amount,SecureString iban)
        {
            IAccount accountToWithdraw = checkIfAccountExistByIban(iban);

            accountToWithdraw.Withdraw(amount);

            return $"Seccessfully withdraw {amount}$ from your account.";
        }

        public string Report(SecureString id)
        {
           // var person = CheckIfPersonExistByID(id);
            var sb = new StringBuilder();
            sb.AppendLine($"Account Name: {person.GetFullName} with {person.Accounts.Count}");
            foreach (var account in person.Accounts)
            {
                sb.AppendLine(account.ToString());
                sb.AppendLine(SepratorOfAccounts);
            }

            return sb.ToString().TrimEnd();
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

        public IReadOnlyCollection<IAccount> TakeAllAccounts() => this.accountRepository.Models;

        private IAccount checkIfAccountExistByIban(SecureString iban)
        {
            var ibanToLookFor = DecriptSecureString(iban);

            foreach (var accountToCheck in accountRepository.Models)
            {
                var ibanOfAccount = DecriptSecureString(accountToCheck.Iban);
                if(ibanOfAccount==ibanToLookFor)
                {
                    return accountToCheck;
                }
            }

            return null;
        }
    }
}

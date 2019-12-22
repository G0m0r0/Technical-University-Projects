namespace BankAccountManager.Core
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

    public class Controller : IController
    {
        private const string SepratorOfAccounts = "-------------------";

        public Controller()
        {
            this.persons = new List<IPerson>();
            this.accountRepository = new AccountRepository();
        }

        private List<IPerson> persons;
        private IRepository<IAccount> accountRepository;

        public string AddAccount(string accountType,SecureString idPerson, decimal balance, float interestRate, SecureString Iban)
        {
            IAccount account = null;
            IPerson person = CheckIfPersonExistByID(idPerson);

            if(accountType=="CheckingAccount")
            {
                account = new CheckingAccount(person, balance, interestRate, Iban);
            }
            else if(accountType== "ChildSavingsAccount")
            {
                account = new ChildSavingsAccount(person, balance, interestRate, Iban);
            }
            else if(accountType=="RetirmentAccount")
            {
                account = new RetirmentAccount(person, balance, interestRate, Iban);
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
            IPerson person = new Person(firstName,lastName,age,ID);
            this.persons.Add(person);

            return "Seccessfully added person!";
        }

        public string CalculateAllMoney(SecureString id)
        {
            var person = CheckIfPersonExistByID(id);
            var sum= person.Accounts.Sum(x => x.GetBalance);

            return $"Money available in all accounts {sum:F2}.";
        }

        public string Deposit(SecureString id,decimal amount,SecureString iban)
        {
            var person = CheckIfPersonExistByID(id);

            var accountOfPerson = checkIfAccountExistByIban(iban,person);

            accountOfPerson.Deposit(amount);

            return $"Seccessfully deposited {amount} to {accountOfPerson.Iban}.";
        }
        public string Withdraw(SecureString id,decimal amount,SecureString iban)
        {
            var person = CheckIfPersonExistByID(id);

            var accountOfPerson = checkIfAccountExistByIban(iban, person);

            accountOfPerson.Withdraw(amount);

            return $"Seccessfully withdraw {amount} from {accountOfPerson.Iban}";
        }

        public string Report(SecureString id)
        {
            var person = CheckIfPersonExistByID(id);
            var sb = new StringBuilder();
            sb.AppendLine($"Account Name: {person.GetFullName} with {person.Accounts.Count}");
            foreach (var account in person.Accounts)
            {
                sb.AppendLine(account.ToString());
                sb.AppendLine(SepratorOfAccounts);
            }

            return sb.ToString().TrimEnd();
        }

        private IAccount checkIfAccountExistByIban(SecureString iban, IPerson person)
        {
            var account = person.Accounts.FirstOrDefault(x => x.Iban == iban);
            if (account == null)
            {
                throw new ArgumentException("Thre is no iban matching given one!");
            }
            return account;
        }

        private IPerson CheckIfPersonExistByID(SecureString id)
        {
            var person = this.persons.FirstOrDefault(x => x.Id == id);
            if (person == null)
            {
                throw new ArgumentException("There is no person matching given id!");
            }
            return person;
        }
    }
}

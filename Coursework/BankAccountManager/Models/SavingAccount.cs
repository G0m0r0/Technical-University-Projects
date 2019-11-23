namespace BankAccountManager.Models
{
    using System;
    using System.Security;
    using System.Text;
    abstract class SavingAccount : Account
    {
        protected SavingAccount(Person person, decimal balance, float interestRate, SecureString Iban) 
            : base(person, balance, interestRate, Iban)
        {
        }

 

    }
}

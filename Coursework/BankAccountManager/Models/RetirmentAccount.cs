namespace BankAccountManager.Models
{
    using System;
    using System.Security;
    using System.Text;
    class RetirmentAccount : SavingAccount
    {
        private const decimal minimumBalanceForRetirment = 2000;
        public RetirmentAccount(Person person, decimal balance, float interestRate, SecureString Iban) 
            : base(person, balance, interestRate, Iban)
        {
        }
    }
}

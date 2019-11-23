namespace BankAccountManager.Models
{
    using System;
    using System.Security;
    using System.Text;
    class ChildSavingsAccount : SavingAccount
    {
        private const decimal minimumBalanceForChild = 500;
        public ChildSavingsAccount(Person person, decimal balance, float interestRate, SecureString Iban) 
            : base(person, balance, interestRate, Iban)
        {
        }
    }
}

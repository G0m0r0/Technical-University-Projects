namespace BankAccountManager.Models.Accounts
{
    using System;
    using System.Security;
    using Models.Accounts.Contracts;
    using BankAccountManager.Models.Person.Contracts;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using BankAccountManager.Models.Transactions.Contracts;
    using BankAccountManager.Models.Enums;
    using BankAccountManager.Models.Transactions;
    using System.Linq;

    public abstract class Account : IAccount
    {
        private const int IBANLenght = 13;
        private const float maxInterestRate = 5.0F;
        private const string separator = "___";

        protected Account(IPerson person, decimal balance, float interestRate, SecureString Iban)
        {
            this.Person = person;
            this.Balance = balance;
            this.InterestRate = interestRate;
            this.IBAN = Iban;
            this.transactions = new List<ITransaction>();
            DateTime TimeOfCreation = DateTime.Now;
        }

        private IPerson person;
        protected decimal balance;
        private float interestRate;
        private SecureString Iban;
        public IList<ITransaction> Transactions
            => this.transactions.AsReadOnly();
        protected DateTime TimeOfCreation { get; }

        public SecureString IBAN
        {
            get { return Iban; }
            private set
            {
                if (String.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentException("IBAN cannot be null or empty!");
                }
                if (value.Length < 0 && value.Length > IBANLenght)
                {
                    throw new ArgumentException("IBAN lenght should be between 0 and 13 symbols");
                }

                Iban = value;
            }
        }

        public virtual float InterestRate
        {
            get { return interestRate; }
            protected set
            {
                if (value < 0.0F || value > maxInterestRate)
                {
                    throw new ArgumentException($"Interest rate should be between 0 and {maxInterestRate}%");
                }
                interestRate = value;
            }
        }

        public virtual decimal Balance
        {
            get { return balance; }
            protected set
            {
                balance = value;
            }
        }

        public IPerson Person
        {
            get { return person; }
            private set
            {
                person = value ?? throw new ArgumentNullException("Person doesn't exsist"); ;
            }
        }
        protected List<ITransaction> transactions;

        public decimal GetBalance => this.Balance;

        SecureString IAccount.Iban => this.IBAN;

        public virtual void Withdraw(decimal amount)
        {
            if (CheckPossitiveAmount(amount) && IsBalanceEnough(amount))
            {
                this.Balance -= amount;
            }

            AddToTransactionHistory(amount, "Withdraw");
        }

        public virtual void Deposit(decimal amount)
        {
            if (CheckPossitiveAmount(amount))
            {
                this.Balance += amount;
            }

            AddToTransactionHistory(amount, "Deposit");
        }

        protected void AddToTransactionHistory(decimal amount, string type)
        {
            ITransaction currentTransaction = null;
            if (type == "Withdraw")
            {
                currentTransaction = new TransactionCurrent(amount, TypeTransaction.Withdraw);
            }
            else if (type == "Deposit")
            {
                currentTransaction = new TransactionCurrent(amount, TypeTransaction.Deposit);
            }
            else if (type == "InterestIncome")
            {
                currentTransaction = new TransactionCurrent(amount, TypeTransaction.InterestIncome);
            }

            this.transactions.Add(currentTransaction);
        }

        protected bool IsBalanceEnough(decimal amountToWithdraw)
        {
            if (amountToWithdraw > this.Balance)
            {
                throw new ArgumentException("Insufficient amount, not enough money to widraw!");
            }

            return true;
        }

        protected bool CheckPossitiveAmount(decimal amount)
        {
            if (amount <= 0.0m)
            {
                throw new ArgumentOutOfRangeException("Negative amount!");
            }

            return true;
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

        public override string ToString()
        {
            var iban = DecriptSecureString(this.IBAN);
            return $"IBAN{iban}{separator}{this.Balance}$";
        }

        public void AddInterest()
        {
            var interestForDay = new List<decimal>();
            decimal interestForMonth=0;

            interestForDay.Add(this.Balance * (1 + (decimal)this.interestRate / 100));

            if (interestForDay.Count > 27)
                interestForMonth = TakeInterestForMonth(interestForDay);

            if (interestForMonth != 0)
            {
                this.Balance += interestForMonth;
                AddToTransactionHistory(interestForMonth, "InterestIncome");
            }            
        }

        private decimal TakeInterestForMonth(List<decimal> interestForDay)
        {
            decimal interest = 0;
            switch (DateTime.Now.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    if (interestForDay.Count == 31)
                    {
                        interest /= interestForDay.Sum() / 31;
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    if (interestForDay.Count == 30)
                    {
                        interest = interestForDay.Sum() / 30;
                    }
                    break;
                case 2:
                    if (DateTime.IsLeapYear(DateTime.Now.Year))
                    {
                        if (interestForDay.Count == 29)
                        {
                            interest = interestForDay.Sum() / 29;
                        }
                    }
                    else
                    {
                        if (interestForDay.Count == 28)
                        {
                            interest = interestForDay.Sum() / 28;
                        }
                    }
                    break;
            }

            return Math.Round(interest, 2);
        }
    }
}

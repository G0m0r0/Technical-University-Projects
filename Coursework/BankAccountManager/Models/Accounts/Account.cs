namespace BankAccountManager.Models.Accounts
{
    using System;
    using System.Security;
    using Person;
    using Models.Accounts.Contracts;
    using BankAccountManager.Models.Person.Contracts;
    using System.Runtime.InteropServices;

    public abstract class Account : IAccount
    {
        private const int IBANLenght = 13;
        private const float maxInterestRate = 1.0F;
        private const string separator= "___";

        protected Account(IPerson person, decimal balance, float interestRate, SecureString Iban)
        {
            this.Person = person;
            this.Balance = balance;
            this.InterestRate = interestRate;
            this.IBAN = Iban;
        }

        private IPerson person;
        protected decimal balance;
        private float interestRate;
        private SecureString Iban;

        public SecureString IBAN
        {
            get { return Iban; }
            private set
            {
                if (String.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentException("IBAN cannot be null or empty!");
                }

                Iban = value;
            }
        }

        public float InterestRate
        {
            get { return interestRate; }
            protected set
            {
                if (value < 0.0F || value > maxInterestRate)
                {
                    throw new ArgumentException("Interest rate should be between 0 and 1");
                }
                interestRate = value;
            }
        }

        //TODO: validation balance
        public decimal Balance
        {
            get { return balance; }
            protected set 
            { 
                if(value<0)
                {
                    throw new ArgumentException("Balance can not be negative!");
                }
                        
                balance = value; 
            }
        }

        public IPerson Person
        {
            get { return person; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Person doesn't exsist");
                }
                person = value;
            }
        }

        public decimal GetBalance => this.Balance;

        SecureString IAccount.Iban => this.IBAN;

        public virtual void Withdraw(decimal amount)
        {
            if (CheckPossitiveAmount(amount) && IsBalanceEnough(amount))
            {
                this.Balance -= amount;
            }
        }

        protected bool IsBalanceEnough(decimal amountToWithdraw)
        {
            if (amountToWithdraw > this.Balance)
            {
                throw new ArgumentException("Insufficient amount, not enough money to widraw!");
            }

            return true;
        }

        public virtual void Deposit(decimal amount)
        {
            if (CheckPossitiveAmount(amount))
            {
                this.Balance += amount;
            }
        }
        //TODO: impliment interest rate montly
        public virtual void AddInterests()
        {
            this.Balance += (this.Balance * (Decimal)(this.InterestRate / 12.0));
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
    }
}

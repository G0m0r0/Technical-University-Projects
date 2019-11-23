namespace BankAccountManager.Models
{
    using System;
    using System.Security;
    public abstract class Account
    {
        private const int IBANLenght = 13;
        private const float maxInterestRate = 1.0F;

        protected Account(Person person, decimal balance, float interestRate, SecureString Iban)
        {
            this.Person = person;
            this.Balance = balance;
            this.InterestRate = interestRate;
            this.IBAN = Iban;
        }

        public Person person;
        protected decimal balance;
        private float interestRate;
        private SecureString Iban;

        public SecureString IBAN
        {
            get { return Iban; }
            set
            {
                if (value.Length < 0 || value.Length > IBANLenght)
                    Iban = value;
            }
        }

        public float InterestRate
        {
            get { return interestRate; }
            set
            {
                if (value < 0.0F || value > maxInterestRate)
                {
                    throw new Exception("Interest rate should be between 0 and 1");
                }
                interestRate = value;
            }
        }

        //TODO: validation balance
        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public Person Person
        {
            get { return person; }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Person doesn't exsist");
                }
                person = value;
            }
        }

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
                throw new Exception("Insufficient amount, not enough money to widraw!");
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
                throw new Exception("Negative amount!");
            }

            return true;
        }

        public override string ToString()
        {
            return $"Person{Person.FirstName} {Person.LastName} have ${Balance} in account {IBAN}";
        }
    }
}

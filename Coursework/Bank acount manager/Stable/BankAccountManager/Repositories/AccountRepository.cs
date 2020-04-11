namespace BankAccountManager.Repositories
{
    using BankAccountManager.Models.Accounts.Contracts;
    using BankAccountManager.Repositories.Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Security;

    public class AccountRepository : IRepository<IAccount>,IEnumerable<IAccount>,IAccountEnumerable
    {
        public AccountRepository()
        {
            this.accounts = new List<IAccount>();
        }
        private readonly List<IAccount> accounts;
        public IReadOnlyCollection<IAccount> Models => this.accounts.AsReadOnly();

        public void Add(IAccount model)
        {
            if(model==null)
            {
                throw new ArgumentNullException("Account cannot be null!");
            }
            this.accounts.Add(model);
        }

        public bool FindByIdentification(SecureString Iban)
        {
            var decriptedIbanToLookFor = DecriptSecureString(Iban);

            foreach (var account in this.accounts)
            {
                var IbanToCompare = DecriptSecureString(account.Iban);
                if(IbanToCompare==decriptedIbanToLookFor)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(IAccount model)
        {
            if(model==null)
            {
                throw new ArgumentNullException("Account cannot be null!");
            }

            return this.accounts.Remove(model);
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

        public IEnumerator<IAccount> GetEnumerator()
        {
            foreach (var account in this.accounts)
            {
                yield return account;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

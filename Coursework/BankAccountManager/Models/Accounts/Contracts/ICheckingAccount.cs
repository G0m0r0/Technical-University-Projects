using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountManager.Models.Accounts.Contracts
{
    public interface ICheckingAccount
    {
        void ActivateOverdraft(decimal amountOverdraft);
        void DeactivateOverdraft();
    }
}

using System.Security;

namespace BankAccountManager.Contracts
{
    interface IPerson
    {
        public string FirstName {get;}
        public string LastName { get; }
        public int Age { get; }
        public SecureString Id { get; }
    }
}

namespace BankAccountManager.Models.Person.Contracts
{
    using System.Security;
    public interface IPerson:IPersonAccount
    {
        public string FirstName { get; }

        public string LastName { get; }

        public int Age { get; }

        public SecureString Id { get; }
    }
}

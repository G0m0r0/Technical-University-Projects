namespace BankManagerLib.Models.Person.Contracts
{
    using System.Security;
    public interface IPerson:IPersonAccount
    {
        string FirstName { get; }

        string LastName { get; }

        int Age { get; }

        SecureString Id { get; }
    }
}

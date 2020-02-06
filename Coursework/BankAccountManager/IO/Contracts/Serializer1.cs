namespace BankAccountManager.IO.Contracts
{
    using BankAccountManager.Repositories;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    class Serializer1
    {

        public void SerializeObject(string fileName, AccountRepository accountRepo)
        {
            Stream stream = File.Open(fileName, FileMode.Create);
            BinaryFormatter bFormater = new BinaryFormatter();
            bFormater.Serialize(stream, accountRepo);
            stream.Close();
        }

        public AccountRepository DeSerializeObject(string filename)
        {
            AccountRepository objectToSerialize;
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            objectToSerialize = (AccountRepository)bFormatter.Deserialize(stream);
            stream.Close();
            return objectToSerialize;
        }

    }
}

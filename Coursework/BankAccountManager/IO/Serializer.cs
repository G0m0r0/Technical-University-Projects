namespace BankAccountManager.IO
{
    using BankAccountManager.Repositories;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    public class Serializer
    {
        public void SerializeObject(string fileName,UserRepository userRepo)
        {
            Stream stream = File.Open(fileName, FileMode.Create);
            BinaryFormatter bFormater = new BinaryFormatter();
            bFormater.Serialize(stream, userRepo);
            stream.Close();
        }

        public UserRepository DeSerializeObject(string filename)
        {
            UserRepository objectToSerialize;
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            objectToSerialize = (UserRepository)bFormatter.Deserialize(stream);
            stream.Close();
            return objectToSerialize;
        }
    }
}

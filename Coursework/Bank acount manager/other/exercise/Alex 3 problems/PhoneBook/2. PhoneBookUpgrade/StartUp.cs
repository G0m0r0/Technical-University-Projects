using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Xml;

namespace PhoneBook
{
    class StartUp
    {
        static Phonebook phonebook;
        static void Main(string[] args)
        {
            //test
            //Person person1 = new Person("ivan", new List<string> { "1234" }, new List<string> { "ivan@gmail.com" });
            //Person person2 = new Person("petar", new List<string> { "2345" }, new List<string> { "petaR@gmail.com" });
            //List<Person> personlist = new List<Person>();
            //personlist.Add(person1);
            //personlist.Add(person2);

           // phonebook = new Phonebook(personlist);

            string path = @"D:\Programming\Softuni\Lesons\C# Advance\Defining classes\Defining classes\bin\Debug\netcoreapp3.0\testXML.txt";

            FileStream streamReader = new FileStream(path, FileMode.OpenOrCreate);
            BinaryFormatter formater = new BinaryFormatter();
            if (streamReader.Length>0)
                phonebook = (Phonebook)formater.Deserialize(streamReader);
            streamReader.Close();

            Console.WriteLine("Options");
            Console.WriteLine("Add (person), Find (person), Delete (person),Print (all), end:");
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] tokens = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (tokens[0].ToLower())
                {
                    case "add":
                        Console.WriteLine("");
                        Console.WriteLine("Person was successfully addes!");
                        break;
                    case "find":
                        

                        if (true)
                        {
                            Console.WriteLine("Phone number found!");
                            
                        }
                        else
                        {
                            Console.WriteLine("Phone number not found!");
                        }
                        break;
                    case "delete":
                      

                        if (true)
                        {
                            
                            Console.WriteLine($" has been deleted!");
                        }
                        else
                        {
                            Console.WriteLine($"Person with number {tokens[1]} is not found!");
                        }
                        break;
                    case "print":
                        PrintPhonebook();
                        break;
                    default:
                        Console.WriteLine("Command is not found!");
                        Console.WriteLine("Add person, Find person, Delete person, end:");
                        break;
                }
            }

            foreach (var person in phonebook)
            {
                Console.WriteLine(person.ToString());
            }

            FileStream streamWriter = new FileStream(path, FileMode.OpenOrCreate);
            formater.Serialize(streamWriter, phonebook);
            streamWriter.Close();
        }

        private static void PrintPhonebook()
        {
            foreach (var person in phonebook)
            {
                Console.WriteLine(person);
            }
        }
    }
}

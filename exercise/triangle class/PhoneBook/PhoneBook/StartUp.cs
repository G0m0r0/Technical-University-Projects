using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PhoneBook
{
    class StartUp
    {
        static List<Person> phoneBook;
        static void Main(string[] args)
        {
            phoneBook = new List<Person>();

            string path = @"D:\Programming\University\exercise\triangle class\PhoneBook\PhoneBook\bin\Debug\netcoreapp3.0\text.txt";
            // using (StreamReader reader = new StreamReader("text.txt"))
            // {
            //     string line;
            //     while ((line = reader.ReadLine()) != null)
            //     {
            //         string[] tokens = line
            //         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //         .ToArray();
            //         phoneBook.Add(personDate(tokens));
            //     }
            // }
            IFormatter formatter = new BinaryFormatter();


            Stream streamRead = new FileStream(path, FileMode.Open, FileAccess.Read);
            Person textToDeserialize;
            while ((textToDeserialize = (Person)formatter.Deserialize(streamRead))!=null)
            {
                phoneBook.Add(textToDeserialize);
            }
            streamRead.Close();


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
                        phoneBook.Add(personDate(tokens));
                        Console.WriteLine("Person was successfully addes!");
                        break;
                    case "find":
                        Person personToSearch = phoneBook.FirstOrDefault(x => x.PhoneNumber == tokens[1]);

                        if (personToSearch != null)
                        {
                            Console.WriteLine("Phone number found!");
                            Console.WriteLine(personToSearch.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Phone number not found!");
                        }
                        break;
                    case "delete":
                        Person personToDelete = phoneBook.FirstOrDefault(x => x.PhoneNumber == tokens[1]);

                        if (personToDelete != null)
                        {
                            phoneBook.Remove(personToDelete);
                            Console.WriteLine($"{personToDelete.Name} has been deleted!");
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

            // using (StreamWriter writer= new StreamWriter("text.txt"))
            // {
            //     for (int i = 0; i < phoneBook.Count; i++)
            //     {
            //         writer.WriteLine(phoneBook[i])
            //     }
            // }

            foreach (var person in phoneBook)
            {
                Console.WriteLine(person.ToString());
            }

            Stream streamWrite = new FileStream(path, FileMode.Create, FileAccess.Write);
            for (int i = 0; i < phoneBook.Count; i++)
            {
                formatter.Serialize(streamWrite, phoneBook[i]);
            }
            streamWrite.Close();

        }

        private static void PrintPhonebook()
        {
            foreach (var person in phoneBook)
            {
                Console.WriteLine(person);
            }
        }

        private static Person personDate(string[] tokens)
        {
            string name = tokens[1];
            string phone = tokens[2];
            string email = tokens[3];
            Person person = new Person(name, phone, email);

            return person;
        }
    }
}

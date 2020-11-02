using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook
{
    [Serializable]
    public class Phonebook:IEnumerable<Person>
    {      
        public List<Person> PhonebookList { set; get; }
        public Phonebook(List<Person> phonebook)
        {
            this.PhonebookList = phonebook;
        }

        public Phonebook()
        {
            this.PhonebookList = new List<Person>();
        }

        public void Add(Person person)
        {
            this.PhonebookList.Add(person);
        }

        public IEnumerator<Person> GetEnumerator()
        {
            foreach (var person in this.PhonebookList)
            {
                yield return person;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

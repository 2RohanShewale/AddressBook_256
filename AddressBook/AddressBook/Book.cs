using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace AddressBook
{
    internal class Book
    {
        public List<BookAddress> addressBooks = new List<BookAddress>();
        public Dictionary<string, List<ContactPerson>> CityDictionary = new Dictionary<string, List<ContactPerson>>();
        public Dictionary<string, List<ContactPerson>> StateDictionary = new Dictionary<string, List<ContactPerson>>();

        public string CreateAddressBook()
        {
            WriteLine("\nCreate address book");
            Write("Enter the name of the address Book: "); string _name = ReadLine();
            if (addressBooks.FirstOrDefault(a => a.name == _name) == null)
            {
                BookAddress book = new BookAddress() { name = _name };
                addressBooks.Add(book);
                WriteLine("Address Book created");
            }
            else
            {
                WriteLine("Address Book similar name already exists");
            }
            return _name;
        }

        public void DisplayCreatedBook()
        {
            foreach (var addressBook in addressBooks)
            {
                WriteLine(addressBook.name);
            }
        }
        public BookAddress ChangeAddressBook(string name)
        {
            return addressBooks.Find(x => x.name == name);
        }
        public void DisplayByCityOrState(Predicate<ContactPerson> predicate)
        {
            List<ContactPerson> byCityOrState = new List<ContactPerson>();
            foreach (var addressbook in addressBooks)
            {
                addressbook.contacts.ForEach(contact => { if (predicate(contact)) { byCityOrState.Add(contact); }; });
            }
            if (byCityOrState != null)
            {
                byCityOrState.ForEach(contact => contact.Display());
            }

        }
        public void CreateDictionaryCityAndState()
        {
            foreach (var addressbook in addressBooks)
            {
                foreach (ContactPerson contact in addressbook.contacts)
                {
                    //for City
                    if (CityDictionary.ContainsKey(contact.City))
                        CityDictionary[contact.City].Add(contact);
                    else
                        CityDictionary.Add(contact.City, new List<ContactPerson> { contact });

                    //for State
                    if (StateDictionary.ContainsKey(contact.State))
                        StateDictionary[contact.State].Add(contact);
                    else
                        StateDictionary.Add(contact.State, new List<ContactPerson> { contact });
                }
            }
        }
        public void DisplayByCityAndState()
        {
            CreateDictionaryCityAndState();
            Console.WriteLine("Cities: ");
            foreach (KeyValuePair<string, List<ContactPerson>> item in CityDictionary)
            {
                Console.WriteLine(">>" + item.Key);
                foreach (var contact in item.Value)
                {
                    Console.WriteLine("    " + contact.FirstName + " " + contact.LastName);
                }
                Console.WriteLine();
            }
            WriteLine("States: ");
            foreach (KeyValuePair<string, List<ContactPerson>> item in StateDictionary)
            {
                Console.WriteLine(">>" + item.Key);
                foreach (var contact in item.Value)
                {
                    Console.WriteLine("    " + contact.FirstName + " " + contact.LastName);
                }
                Console.WriteLine();
            }
        }
        public void DisplayByCityNumber(string city)
        {
            CreateDictionaryCityAndState();
            Console.WriteLine($"City: {city} : Count {CityDictionary[city].Count}");
        }

    }
}

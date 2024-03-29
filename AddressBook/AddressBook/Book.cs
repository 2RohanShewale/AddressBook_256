﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using static System.Console;

namespace AddressBook
{
    public class Book
    {
        public List<BookAddress> addressBooks = new List<BookAddress>();
        public Dictionary<string, List<ContactPerson>> CityDictionary = new Dictionary<string, List<ContactPerson>>();
        public Dictionary<string, List<ContactPerson>> StateDictionary = new Dictionary<string, List<ContactPerson>>();

        public string CreateAddressBook()
        {
            string bookPath = @"C:\Users\shewa\RFP-256\AddressBook_256\AddressBook\AddressBook\Books\";
            WriteLine("\nCreate address book");
            Write("Enter the name of the address Book: "); string _name = ReadLine();
            if (addressBooks.FirstOrDefault(a => a.name == _name) == null)
            {
                BookAddress book = new BookAddress() { name = _name };
                addressBooks.Add(book);
                File.Create(bookPath + _name+ ".csv").Close();
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
        public void SortByCityStateOrZip()
        {
            List<ContactPerson> contacts = GetAllContacts();
            WriteLine("\n1.Sort By City \n2.Sort By State.\n3.Sort By Zip\n Enter a choice: ");
            int choice = Convert.ToInt32(ReadLine());
            switch (choice)
            {
                case 1:
                    contacts.OrderBy(x => x.City).ToList().ForEach(x=>x.Display());
                    break;
                case 2:
                    contacts.OrderBy(x => x.State).ToList().ForEach(x => x.Display());
                    break;
                case 3:
                    contacts.OrderBy(x => x.Zip).ToList().ForEach(x => x.Display());
                    break;
            }
            Console.WriteLine();
        }
        public void SortByFirstName()
        {
            List<ContactPerson> contacts = GetAllContacts();
            foreach(var contact in contacts.OrderBy(x=> x.FirstName))
            {
                contact.Display();
            }
        }
        public List<ContactPerson> GetAllContacts()
        {
            List<ContactPerson> allContact = new List<ContactPerson>();
            foreach (var addressbook in addressBooks)
            {
                addressbook.contacts.ForEach(x => allContact.Add(x));
            }
            return allContact;
        }
        public void DisplayByCityNumber(string city)
        {
            CreateDictionaryCityAndState();
            Console.WriteLine($"City: {city} : Count {CityDictionary[city].Count}");
        }
        public void WriteToJsonFile()
        {
            string filePath = @"C:\Users\shewa\RFP-256\AddressBook_256\AddressBook\AddressBook\JSON\book.json";
            JsonSerializer jsonSerializer= new JsonSerializer();
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
                {
                    jsonSerializer.Serialize(jsonWriter, Formatting.Indented);
                    jsonSerializer.Serialize(jsonWriter, this);
                }
            }
        }
    }
}

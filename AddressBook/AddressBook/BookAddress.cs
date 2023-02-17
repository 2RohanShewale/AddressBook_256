using System;
using System.Collections.Generic;
using static System.Console;
using static AddressBook.GeneratingContacts;

namespace AddressBook
{
    internal class BookAddress
    {
        public string name;
        public List<ContactPerson> contacts = new List<ContactPerson>();//multiple Contacts
        public void CreateContact()
        {
            String _FirstName, _LastName, _Address, _City, _State, _PhoneNumber, _Zip, _Email;
            WriteLine("\nCreate Contact");
            Write("First Name: "); _FirstName = ReadLine();
            Write("Last Name: "); _LastName = ReadLine();
            if (!doesExists(_FirstName, _LastName))
            {
                Write("Address: "); _Address = ReadLine();
                Write("City: "); _City = ReadLine();
                Write("State: "); _State = ReadLine();
                Write("Zip: "); _Zip = ReadLine();
                Write("Phone Number: "); _PhoneNumber = ReadLine();
                Write("Email: "); _Email = ReadLine();

                ContactPerson contact = new ContactPerson()
                {
                    FirstName = _FirstName,
                    LastName = _LastName,
                    Address = _Address,
                    City = _City,
                    State = _State,
                    PhoneNumber = _PhoneNumber,
                    Zip = _Zip,
                    Email = _Email
                };
                contacts.Add(contact);
            }
            else
            {
                Console.WriteLine("\nContact under same name already exists");
            }

        }
        public void Display()
        {
            foreach (var contact in contacts)
                contact.Display();
        }
        public void EditContact()
        {
            WriteLine("\nEdit Contact");
            WriteLine("Enter First Name: "); string FirstName = ReadLine();
            WriteLine("Enter Last Name: "); string LastName = ReadLine();
            foreach (var contact in contacts)
            {
                if (FirstName == contact.FirstName && LastName == contact.LastName)
                {
                    contact.Edit();
                }
            }
            Display();
        }
        public void DeleteContact()
        {
            WriteLine("\nDelete Contact");
            Write("Enter First Name: "); string FirstName = ReadLine();
            Write("Enter Last Name: "); string LastName = ReadLine();
            foreach (var contact in contacts)
            {
                if (FirstName == contact.FirstName && LastName == contact.LastName)
                {
                    contacts.Remove(contact);
                    break;
                }
            }
            Display();
        }
        public void GeneratingRandomContacts()
        {
            WriteLine("\nGeneration Random Contacts");
            Write("How many Contacts to generate: "); int number = Convert.ToInt32(ReadLine());
            for(int i= 0; i < number;)
            {
                Random random = new Random();
                string _FirstName = firstNames[random.Next(firstNames.Length)];
                string _LastName = lastNames[random.Next(lastNames.Length)];
                if (!doesExists(_FirstName, _LastName))
                {
                    string _state = GetState();
                    ContactPerson contact = new ContactPerson()
                    {
                        FirstName = _FirstName,
                        LastName = _LastName,
                        Address = "Some Location",
                        State = _state,
                        City = GetCity(_state),
                        Zip = ZipCode(),
                        PhoneNumber = PhoneNubmer(),
                        Email = $"{_FirstName.ToLower()}@gmail.com"
                    };
                    contacts.Add(contact);
                    i++;
                }

            }
        }
        public bool doesExists(string _FirstName, string _LastName)
        {
            if (contacts != null)
            {
                foreach (var contact in contacts)
                {
                    if (contact.FirstName == _FirstName && contact.LastName == _LastName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

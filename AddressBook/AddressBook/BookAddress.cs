using System;
using System.Collections.Generic;
using static System.Console;

namespace AddressBook
{
    internal class BookAddress
    {
        public List<ContactPerson> contacts = new List<ContactPerson>();//multiple Contacts
        public void CreateContact()
        {
            String _FirstName, _LastName, _Address, _City, _State, _PhoneNumber, _Zip, _Email;
            WriteLine("Create Contact");
            Write("First Name: "); _FirstName = ReadLine();
            Write("Last Name: "); _LastName = ReadLine();
            Write("Address: "); _Address = ReadLine();
            Write("City: "); _City = ReadLine();
            Write("State: "); _State = ReadLine();
            Write("Zip: "); _Zip = ReadLine();
            Write("Phone Number: "); _PhoneNumber = ReadLine();
            Write("Email: "); _Email = ReadLine();

            if (!doesExists(_FirstName,_LastName))
            {
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
                Console.WriteLine("Similar Contact Already Exists");
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
                }
            }
            Display();
        }
        public bool doesExists(string _FirstName, string _LastName)
        {
            if (contacts != null)
            {
                foreach (var contact in contacts)
                {
                    if (contact.FirstName == _FirstName && contact.LastName == _LastName)
                    {
                        WriteLine("Exists");
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

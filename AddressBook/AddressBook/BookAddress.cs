﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using static AddressBook.GeneratingContacts;
using static System.Console;

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
            ContactPerson temp = new ContactPerson() { FirstName = _FirstName, LastName = _LastName };
            if (contacts.FirstOrDefault(p=>p.Equals(temp)) == null)
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
                Warning("Contact under same name already exists");
            }

        }
        public void Display()
        {
            if (contacts.Count != 0)
            {
                foreach (var contact in contacts)
                    contact.Display();
            }
            else
            {
                Console.WriteLine("This it ");
                Warning("There are no contacts to display");
            }

        }
        public void EditContact()
        {
            if (contacts.Count != 0)
            {
                WriteLine("\nEdit Contact");
                WriteLine("Enter First Name: "); string FirstName = ReadLine();
                WriteLine("Enter Last Name: "); string LastName = ReadLine();
                ContactPerson contact = contacts.FirstOrDefault(x => x.FirstName == FirstName&& x.LastName== LastName);
                if (contact != null)
                {
                    contact.Edit();
                }
                else
                {
                    Warning(">>>There is not contact under such name");
                }
            }
            else { Warning("There are no contact to edit"); }

        }
        public void DeleteContact()
        {
            if (contacts.Count != 0)
            {
                WriteLine("\nDelete Contact");
                Write("Enter First Name: "); string FirstName = ReadLine();
                Write("Enter Last Name: "); string LastName = ReadLine();
                ContactPerson contact = contacts.FirstOrDefault(x => x.FirstName == FirstName && x.LastName == LastName);
                if (contact != null)
                {
                    contacts.Remove(contact);
                }
                else
                {
                    Warning(">>>There is not contact under such name");
                }
                Display();
            }
            else { Warning("There are no contacts to delete"); }
            
        }
        public void GeneratingRandomContacts()
        {
            WriteLine("\nGeneration Random Contacts");
            Write("How many Contacts to generate: "); int number = Convert.ToInt32(ReadLine());
            for (int i = 0; i < number;)
            {
                Random random = new Random();
                string _FirstName = firstNames[random.Next(firstNames.Length)];
                string _LastName = lastNames[random.Next(lastNames.Length)];
                
                if ((contacts.FirstOrDefault(p=>p.FirstName== _FirstName&&p.LastName ==_LastName)) ==null)
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
        private void Warning(String message)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine(message);
            ResetColor();
        }
        public void WriteOrRewriteContacts()
        {
            string path = @"C:\Users\shewa\RFP-256\AddressBook_256\AddressBook\AddressBook\Books\" + name + ".txt";
            using (StreamWriter fileWrite = File.CreateText(path))
            {
                foreach (var contact in contacts)
                {
                    fileWrite.WriteLine("=");
                    fileWrite.WriteLine("First_Name:" + contact.FirstName);
                    fileWrite.WriteLine("Last_Name:" + contact.LastName);
                    fileWrite.WriteLine("Address:" + contact.Address);
                    fileWrite.WriteLine("City:" + contact.City);
                    fileWrite.WriteLine("State:" + contact.State);
                    fileWrite.WriteLine("Zip:" + contact.Zip);
                    fileWrite.WriteLine("PhoneNumber:" + contact.PhoneNumber);
                    fileWrite.WriteLine("Email:" + contact.Email);
                }
            }

        }
        public void ReadExistingContacts(string path)
        {
            
            using (StreamReader file = File.OpenText(path))
            {
 
                string all = file.ReadToEnd();
                all = all.Remove(0,1);
                string[] objects = all.Split('=');
                foreach (var obj in objects)
                {
                    CreateObjectsByReadingFile(obj.Replace("\r",""));
                }
            }
        }
        public void CreateObjectsByReadingFile(string obj)
        { 
            string[] objectElements = obj.Split('\n');
            ContactPerson contact = new ContactPerson();
            int i = 1;
            foreach (var elements in objectElements)
            {
                if (elements != "")
                {
                    string[] element = elements.Split(':');
                    if (element[1] != "")
                    {
                        contact[i] = element[1];
                        i++;
                    }
                    
                }
            }
            contacts.Add(contact);
        }
    }
}

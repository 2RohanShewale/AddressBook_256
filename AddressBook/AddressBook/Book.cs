using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using static System.Console;

namespace AddressBook
{
    internal class Book
    {
        public List<BookAddress> addressBooks = new List<BookAddress>();

        public string CreateAddressBook()
        {
            WriteLine("\nCreate address book");
            Write("Enter the name of the address Book: "); string _name = ReadLine();
            if (!bookExists(_name))
            {
                BookAddress book = new BookAddress() {name = _name };
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
        public bool bookExists(string name)
        {
            if (addressBooks != null)
            {
                foreach (var addressbook in addressBooks)
                {
                    if (addressbook.name == name)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

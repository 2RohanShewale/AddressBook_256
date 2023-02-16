using static System.Console;
using System;
namespace AddressBook
{
    internal class BookAddress
    {
        public void CreateContact()
        {
            String _FirstName, _LastName, _Address, _City, _State, _PhoneNumber, _Zip, _Email;
            WriteLine("Create Contact");
            Write("First Name: ");_FirstName = ReadLine();
            Write("Last Name: "); _LastName = ReadLine();
            Write("Address: "); _Address = ReadLine();
            Write("City: "); _City = ReadLine();
            Write("State: ");_State= ReadLine();
            Write("Zip: "); _Zip = ReadLine();
            Write("Phone Number: "); _PhoneNumber= ReadLine();
            Write("Email: ");_Email = ReadLine();

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
            Display(contact);
        }
        public void Display(ContactPerson contact)
        {
            WriteLine("\nDisplay Contact");
            WriteLine($"Name: {contact.FirstName} {contact.LastName}");
            WriteLine($"Address: {contact.Address} {contact.City} {contact.State} {contact.Zip}");
            WriteLine($"Phone: {contact.PhoneNumber}, Email: {contact.Email}");
        }
    }
}

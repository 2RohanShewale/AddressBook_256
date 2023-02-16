using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class BookAddress
    {
        public void CreateContact()
        {
            ContactPerson contact = new ContactPerson()
            {
                FirstName = "Rohan",
                LastName = "Shewale",
                Address = "L/12",
                City = "Mumbai",
                State = "Mh",
                PhoneNumber = "98696346",
                Zip = "34545",
                Email = "Rohan@.com"
            };
            Display(contact);
        }
        public void Display(ContactPerson contact)
        {
            Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
            Console.WriteLine($"Address: {contact.Address} {contact.City} {contact.State} {contact.Zip}");
            Console.WriteLine($"Phone: {contact.PhoneNumber}, Email: {contact.Email}");
        }
    }
}

using System;

namespace AddressBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*________AddressBook Program_______*");
            Book book = new Book();
            string nameOftheBook = book.CreateAddressBook();
            BookAddress addressBook = book.ChangeAddressBook(nameOftheBook);
            while (true)
            {
                Console.WriteLine($"\n>>>>{addressBook.name}'s book");
                Console.WriteLine("Options: \n1.Create Contact\n2.Display Contact\n3.Edit Contact\n4.Delete Contact\n5.Crete new Address Book\n6.Change Address Book\n7.Generate Random Contacts");
                Console.Write("Choice: "); int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        addressBook.CreateContact();
                        break;
                    case 2:
                        if (addressBook.contacts != null) { addressBook.Display(); }
                        else { Console.WriteLine("Add Atleast One contact"); }
                        break;
                    case 3:
                        if (addressBook.contacts != null) { addressBook.EditContact(); }
                        else { Console.WriteLine("There are no contacts to edit"); }
                        break;
                    case 4:
                        if (addressBook.contacts != null) { addressBook.DeleteContact(); }
                        else { Console.WriteLine("There are no contacts to delete."); }
                        break;
                    case 5:
                        nameOftheBook = book.CreateAddressBook();
                        addressBook = book.ChangeAddressBook(nameOftheBook);
                        break;
                    case 6:
                        book.DisplayCreatedBook();
                        Console.Write("Enter name of the book to open: "); nameOftheBook = Console.ReadLine();
                        addressBook = book.ChangeAddressBook(nameOftheBook);
                        break;
                    case 7:
                        addressBook.GeneratingRandomContacts();
                        break;
                    default:
                        break;
                }
            }


        }
    }
}

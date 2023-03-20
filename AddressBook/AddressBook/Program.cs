using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace AddressBook
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("*________AddressBook Program_______*");
            Book book = new Book();
            string nameOfTheBook = GetNameOfTheAddressBook(book);

            BookAddress addressBook = book.ChangeAddressBook(nameOfTheBook);
            while (true)
            {
                Console.WriteLine($"\n>>>>{addressBook.name}'s book");
                Console.WriteLine("Options: \n1.Create Contact\n2.Display Contact\n3.Edit Contact\n4.Delete Contact\n5.Crete new Address Book\n6.Change Address Book\n7.Search By State Or City(accross all books)\n8.Display By State And City\n9.Disaplay Number of contact by city\n10.Sort By first name\n11.Sort by City,State or Zip\n12.Generate Random Contacts");
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
                        nameOfTheBook = book.CreateAddressBook();
                        addressBook = book.ChangeAddressBook(nameOfTheBook);
                        break;
                    case 6:
                        book.DisplayCreatedBook();
                        Console.Write("Enter name of the book to open: "); nameOfTheBook = Console.ReadLine();
                        addressBook = book.ChangeAddressBook(nameOfTheBook);
                        break;
                    case 7:
                        Console.Write("Enter the name of the city Or State: "); string cityOrState = Console.ReadLine();
                        book.DisplayByCityOrState(contact=> contact.City == cityOrState || contact.State == cityOrState);
                        break;
                    case 8:
                        book.DisplayByCityAndState();
                        break;
                    case 9:
                        Console.Write("Enter the name of the city: ");
                        string city = Console.ReadLine();
                        book.DisplayByCityNumber(city);
                        break;
                    case 10:
                        book.SortByFirstName();
                        break;
                    case 11:
                        book.SortByCityStateOrZip();
                        break;
                    case 12:
                        addressBook.GeneratingRandomContacts();
                        break;
                    default:
                        break;
                }
                addressBook.WriteOrRewriteContacts();
                book.WriteToJsonFile();
            }


        }
        public static string GetNameOfTheAddressBook(Book book)
        {
            string nameOftheBook;
            if (DoesPreviousDataExists())
            {
                Console.WriteLine("Data Already Exists");
                Console.WriteLine("Do you want to reload previous data?");
                Console.Write(@"Press (Y/N) y to load \ n to delete: ");
                string choice = Console.ReadLine();
                if (choice == "Y" || choice == "y")
                {
                    return LoadExistingBooks(book);
                }
                else
                {
                    DeleteExistingBooks();
                    return book.CreateAddressBook();
                }
            }
            else
                return book.CreateAddressBook();
        }
        public static bool DoesPreviousDataExists()
        {
            return Directory.GetFiles(@"C:\Users\shewa\RFP-256\AddressBook_256\AddressBook\AddressBook\Books\").Length != 0;
        }
        public static void DeleteExistingBooks()
        {
            string path = @"C:\Users\shewa\RFP-256\AddressBook_256\AddressBook\AddressBook\Books\";
            DirectoryInfo books = new DirectoryInfo(path);
            FileInfo[] files = books.GetFiles();
            foreach (var file in files)
            {
                file.Delete();
            }
        }
        public static string LoadExistingBooks(Book book)
        {
            string path = @"C:\Users\shewa\RFP-256\AddressBook_256\AddressBook\AddressBook\Books\";
            DirectoryInfo books = new DirectoryInfo(path);
            FileInfo[] files = books.GetFiles();
            foreach (var file in files)
            {
                string name = file.Name;
                name = name.Remove(name.Length - 4);
                BookAddress addressBook = new BookAddress();
                addressBook.name = name;
                addressBook.ReadExistingContacts(path + file.Name);
                book.addressBooks.Add(addressBook);
            }

            return files[0].Name.Remove(files[0].Name.Length - 4);
        }
    }
}

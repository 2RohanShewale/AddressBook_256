using System;

namespace AddressBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*________AddressBook Program_______*");

            BookAddress book = new BookAddress();
            while (true)
            {
                Console.WriteLine("\nOptions: \n1.Create Contact\n2.Display Contact\n3.Edit Contact\n4.Delete Contact");
                Console.Write("Choice: "); int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        book.CreateContact();
                        break;
                    case 2:
                        if (book.contacts != null) { book.Display(); }
                        else { Console.WriteLine("Add Atleast One contact"); }
                        break;
                    case 3:
                        if (book.contacts != null) { book.EditContact(); }
                        else { Console.WriteLine("There are no contacts to edit"); }
                        break;
                    case 4:
                        if (book.contacts != null) { book.DeleteContact(); }
                        else { Console.WriteLine("There are no contacts to delete."); }
                        break;
                    default:
                        break;
                }
            }
            

        }
    }
}

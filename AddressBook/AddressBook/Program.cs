using System;

namespace AddressBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*________AddressBook Program_______*");
            Console.WriteLine("Press any key to create contact");
            Console.ReadKey();
            BookAddress book = new BookAddress();
            book.CreateContact();

            Console.ReadKey();
        }
    }
}

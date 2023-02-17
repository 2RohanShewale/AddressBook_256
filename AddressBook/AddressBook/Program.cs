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
                        book.Display();
                        break;
                    case 3:
                        book.EditContact();
                        break;
                    default:
                        break;
                }
            }
            

            Console.ReadKey();
        }
    }
}

using System;
using System.Web;
using static System.Console;

namespace AddressBook
{
    public class ContactPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public void Display()
        {
            ForegroundColor= ConsoleColor.Blue;
            WriteLine($"\nName: {FirstName} {LastName}");
            ResetColor();
            WriteLine($"Address: {Address} {City} {State} {Zip}");
            WriteLine($"Phone: {PhoneNumber}, Email: {Email}");
        }
        public void Edit()
        {
            WriteLine("\nCurrent Contact info");
            Display();
            Console.WriteLine("Select What to change: ");
            WriteLine("1.First Name 2.Last Name 3.Address 4.City 5.State \n6.Country 7.Zip Code 8.Phone Number 9.Email 10.Cancel\nEnter number : ");
            int num = Convert.ToInt32(ReadLine());

            switch (num)
            {
                case 1: Write("First Name: "); FirstName = ReadLine(); break;
                case 2: Write("Last Name: "); LastName = ReadLine(); break;
                case 3: Write("Address: "); Address = ReadLine(); break;
                case 4: Write("City"); City = ReadLine(); break;
                case 5: Write("State: "); State = ReadLine(); break;
                case 6: Write("Zip Code: "); Zip = ReadLine(); break;
                case 7: Write("Phone Number: "); PhoneNumber = ReadLine(); break;
                case 8: Write("Email: "); Email = ReadLine(); break;
                case 9: WriteLine("Nothing Changed."); break;
                default:
                    break;
            }

        }
        public override bool Equals(object obj)
        {
            return this.FirstName == ((ContactPerson)obj).FirstName && this.LastName == ((ContactPerson)obj).LastName;
        }

    }
}

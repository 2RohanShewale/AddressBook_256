using System;
using System.Web;
using CsvHelper;
using CsvHelper.Configuration;

using static System.Console;

namespace AddressBook
{
    public class ContactPersonMap: ClassMap<ContactPerson>
    {
        public ContactPersonMap() 
        {
            Map(m=>m.FirstName).Name("First Name");
            Map(m => m.LastName).Name("Last Name");
            Map(m => m.Address).Name("Address");
            Map(m => m.City).Name("City");
            Map(m => m.State).Name("State");
            Map(m => m.Zip).Name("Zip Code");
            Map(m => m.PhoneNumber).Name("Phone Number");
            Map(m => m.Email).Name("Email");
        }
    }
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

        public string this[int index]
        {
            get 
            {
                if (index == 1) { return FirstName; }
                else if (index == 2) { return LastName; }
                else if (index == 3) { return Address; }
                else if (index == 4) { return City;}
                else if (index == 5) { return State;}
                else if (index == 6) { return Zip;}
                else if (index == 7) { return PhoneNumber;}
                else if (index == 8) { return Email;}
                return null;
            }
            set 
            {
                if (index == 1) { FirstName = value; }
                else if (index == 2) { LastName = value; }
                else if (index == 3) { Address = value; }
                else if (index == 4) { City = value; }
                else if (index == 5) { State = value; }
                else if (index == 6) { Zip = value; }
                else if (index == 7) { PhoneNumber = value; }
                else if (index == 8) { Email = value; }
            }
        }
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

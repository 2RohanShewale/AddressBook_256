using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook
{
    internal class GeneratingContacts
    {
        public static string[] firstNames = { "Karan", "Rahul", "Rohit", "Ramesh", "Raj", "Ritik", "Pratik", "Ram", "Vaibhav", "Akash", "Vijay", "Amit", "Dinesh", "Dipesh", "Rajesh", "Abhi", "" };
        public static string[] lastNames = { "Gupta", "Shinde", "Sharma", "Verma", "Singh", "Modi", "Shah", "Seth", "Wagh", "Patel", "Basu", "Kumar" };
        public static Dictionary<string, string[]> cityNState = new Dictionary<string, string[]>()
        {
            {"Maharastra", new string[]{ "Mumbai", "Pune", "Thane"} },
            {"Karnataka", new string[]{ "Bengaluru", "Mysore", "Belgaum" } },
            {"Rajastan", new string[]{ "Jaipur", "Kota", "Jaisalmer" } },
            {"Gujrat", new string[]{ "Ahmedabad", "Surat", "Dwarka" } },
        };
        static Random random = new Random();

        public static string ZipCode()
        {
            int firstThree = random.Next(100, 999);
            int SecondThree = random.Next(100, 999);
            return $"{firstThree} {SecondThree}";
        }
        public static string PhoneNubmer()
        {
            long number = random.Next(90000000, 99999999);
            return number.ToString();
        }
        public static string GetState()
        {
            List<string> states = cityNState.Keys.ToList<string>();
            return states[random.Next(states.Count)];
        }
        public static string GetCity(string state)
        {
            string city = "";
            foreach (var item in cityNState)
            {
                if (item.Key == state)
                {
                    city = item.Value[random.Next(item.Value.Length)];
                }
            }
            return city;
        }
    }
}

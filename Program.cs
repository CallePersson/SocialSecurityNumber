using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace SocialSecurityNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string socialSecurityNumber;
            string firstName = "not assigned";
            string lastName = "not assigned";
            if (args.Length != 0)
            {
                socialSecurityNumber = (args[0]);
                
            }
            else
            {
                Console.Write("Please enter your first name: ");
                firstName = Console.ReadLine();
                Console.Write("Please enter your last name: ");
                lastName = Console.ReadLine();
                Console.Write("Please enter Social Security Number (YYMMDD-XXXX)");
                socialSecurityNumber = Console.ReadLine();
            }
            
            string genderNumberString = socialSecurityNumber.Substring(socialSecurityNumber.Length - 2, 1);

            int genderNumber = int.Parse(genderNumberString);

            //tittar om det går att dela med 2, då blir det 0 i rest (true) annars (false)
            bool isFemale = genderNumber % 2 == 0;

            string gender = isFemale ? "Female" : "Male";

            string birthDateString = socialSecurityNumber.Substring(0, 6);

            DateTime birthDate = DateTime.ParseExact(birthDateString, "yyMMdd", CultureInfo.InvariantCulture);

            int age = DateTime.Now.Year - birthDate.Year;

            if (birthDate.Month > DateTime.Today.Month || birthDate.Month == DateTime.Today.Month && birthDate.Day > DateTime.Now.Day)
            {
                // age = age - 1;
                age--;
            }

            //-------------------------------------------------------
            string generation = "unknown";

            if ((DateTime.Now.Year - age) <= 1945)
            {
                generation = "Silent Generation";
            }
            else if ((DateTime.Now.Year - age) >= 1946 && (DateTime.Now.Year - age) < 1965)
            {
                generation = "Baby Boomer";
            }
            else if ((DateTime.Now.Year - age) >= 1965 && (DateTime.Now.Year - age) < 1977)
            {
                generation = "Generation X";
            }
            else if ((DateTime.Now.Year - age) >= 1977 && (DateTime.Now.Year - age) < 1996)
            {
                generation = "Millenial";
            }
            else if ((DateTime.Now.Year - age) >= 1996)
            {
                generation = "Gen Z";
            }
          

            //-------------------------------------------------------
            Console.Clear();


            Console.WriteLine($"Name:\t {firstName} {lastName} \r\nSocial Security Number: {socialSecurityNumber} \r\nGender: {gender}\r\nAge: {age}\r\nGeneration: {generation} ");
                

        }
    }
}

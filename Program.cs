using System;
using System.Globalization;

namespace SocialSecurityNumber
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.Write("Please enter Social Security Number (YYMMDD-XXXX)");

            //deklarerar variabel + tilldelar den ett värde
            string socialSecurityNumber = Console.ReadLine();


            if (args.Length == 1)
            {
                socialSecurityNumber = args[0];
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

            Console.WriteLine($"{gender}, {age}");


        }
    }
}

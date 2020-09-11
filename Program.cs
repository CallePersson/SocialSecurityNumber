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
            string firstName;
            string lastName;
            string generation = "unknown";

            // Getting SSN
            FetchSocialSecurityNumber(args, out socialSecurityNumber, out firstName, out lastName);
            // Calculate Gender
            Gender gender = GetGender(socialSecurityNumber);
            // Calculate Age
            int age = CalculateAge(socialSecurityNumber);
            // Calculate Generation
            generation = GetGeneration(generation, age);

            DisplayingInfo(socialSecurityNumber, firstName, lastName, generation, gender, age);

        }

        private static void DisplayingInfo(string socialSecurityNumber, string firstName, string lastName, string generation, Gender gender, int age)
        {
            Console.Clear();
            Console.WriteLine($@"
            Name:                     {firstName} {lastName}
            Social Security Number:   {socialSecurityNumber}
            Gender:                   {gender}
            Age:                      {age}
            Generation:               {generation} ");
        }

        private static void FetchSocialSecurityNumber(string[] args, out string socialSecurityNumber, out string firstName, out string lastName)
        {
            if (args.Length != 0)
            {
                firstName = (args[0]);
                lastName = (args[1]);
                socialSecurityNumber = (args[2]);
            }
            else
            {
                Console.Write("Please enter your first name: ");
                firstName = Console.ReadLine();

                Console.Write("Please enter your last name: ");
                lastName = Console.ReadLine();

                Console.Write("Please enter Social Security Number (YYYYMMDD-XXXX)");
                socialSecurityNumber = Console.ReadLine();
            }
        }

        private static string GetGeneration(string generation, int age)
        {
            int ageGen = (DateTime.Now.Year - age);

            if (ageGen <= 1945)
            {
                generation = "Silent Generation";
            }
            else if (ageGen >= 1946 && ageGen < 1965)
            {
                generation = "Baby Boomer";
            }
            else if (ageGen >= 1965 && ageGen < 1977)
            {
                generation = "Generation X";
            }
            else if (ageGen >= 1977 && ageGen < 1996)
            {
                generation = "Millenial";
            }
            else if (ageGen >= 1996)
            {
                generation = "Gen Z";
            }

            return generation;
        }

        private static int CalculateAge(string socialSecurityNumber)
        {
            string birthDateString = socialSecurityNumber.Substring(0, 8);

            DateTime birthDate = DateTime.ParseExact(birthDateString, "yyyyMMdd", CultureInfo.InvariantCulture);

            int age = DateTime.Now.Year - birthDate.Year;

            if (birthDate.Month > DateTime.Today.Month || birthDate.Month == DateTime.Today.Month && birthDate.Day > DateTime.Now.Day)
            {
                age--;
            }

            return age;
        }

        private static Gender GetGender(string socialSecurityNumber)
        {
            string genderNumberString = socialSecurityNumber.Substring(socialSecurityNumber.Length - 2, 1);

            int genderNumber = int.Parse(genderNumberString);

            Gender gender;
            if (genderNumber % 2 == 0)
            {
                gender = Gender.Female;
            }
            else
            {
                gender = Gender.Male;
            }
            
            return gender;
        }
    }
    enum Gender
    {
        Female,
        Male
    }
}

using System;
using Assignment_12App;

namespace Assignment_12App
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create a new customer and take input for each property
            Customer customer = new Customer();

            Console.Write("Enter Name: ");
            customer.Name = Console.ReadLine();

            Console.Write("Enter Email: ");
            customer.Email = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            customer.PhoneNumber = Console.ReadLine();

            Console.Write("Enter Date of Birth (yyyy-MM-dd): ");
            string dobInput = Console.ReadLine();

            // Parse the Date of Birth input to DateTime
            if (DateTime.TryParse(dobInput, out DateTime dob))
            {
                customer.DateOfBirth = dob;
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter the date in yyyy-MM-dd format.");
                return;
            }

            // Validate each field using CustomerValidator
            bool isEmailValid = CustomerValidator.ValidateEmail(customer.Email);
            bool isPhoneValid = CustomerValidator.ValidatePhoneNumber(customer.PhoneNumber);
            bool isDOBValid = CustomerValidator.ValidateDateOfBirth(customer.DateOfBirth);

            Console.WriteLine($"\nValidation Results:");
            Console.WriteLine($"Email Valid: {isEmailValid}");
            Console.WriteLine($"Phone Number Valid: {isPhoneValid}");
            Console.WriteLine($"Date of Birth Valid: {isDOBValid}");

            Console.ReadLine();
        }
    }
}

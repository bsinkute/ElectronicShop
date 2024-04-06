using ElectronicShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ElectronicShop.Models
{
    public class UserLoginWindowSelection
    {
        private readonly _userService;
 
        public UserLoginWindowSelection(IUserService userService)
        {
            _userService = userService;
        }

        public void Login()
        {
            // login
            Console.Write("Enter your username:");
            string userName = Console.ReadLine();
            Console.Write("Enter your password:");
            string password = Console.ReadLine();

            // Find user in the list
            User user = _userService.GetUser(userName, password);

            if (user != null)
            {
                Console.WriteLine("Login successful.");
                Console.WriteLine($"Welcome, {user.Username}!");

                // Check if the user is an admin
                if (user.IsAdmin)
                {
                    Console.WriteLine("You are an admin.");
                }
                else
                {
                    Console.WriteLine("You are not an admin.");
                }
            }
        }

        public void RegisterUser(List<User> users)
        {
            Console.Write("Enter your username:");
            string username = Console.ReadLine();
            Console.Write("Enter your password:");
            string password = Console.ReadLine();
            Console.Write("Enter your email address:");

            User newUser = new User { Username = username, Password = password, EmailAddress = emailAddress };

            do
            {
                Console.Write("ERROR email is not valid. Please enter a valid email address: ");
                newUser.EmailAddress = Console.ReadLine();
            } while (!IsValidEmail(newUser.EmailAddress));

            _userService.SaveUser(username, password, emailAddress);

            Console.WriteLine("User registered successfully.");
        }

        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"; //regex pattern check
            return Regex.IsMatch(email, pattern);
        }
    }
}

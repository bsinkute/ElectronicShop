using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicShop
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public decimal Wallet { get; set; }
        public bool IsAdmin { get; set; }
        private string _filePath = @"C:\Users\User\OneDrive\Desktop\.NET\ElectronicStore_Project\Models\users.txt";
        private string _emailAddress;

        public string FilePath()
        {
            return _filePath;
        }

        public string Email()
        {
            return _emailAddress;
        }

        public void AddToWallet(decimal amount)
        {
            Wallet += amount;
        }

        public void DeductFromWallet(decimal amount)
        {
            if (Wallet >= amount)
            {
                Wallet -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient funds in the wallet.");
            }
        }

        public void Login(List<User> users)
        {
            // login
            Console.WriteLine("Enter your username:");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();

            // admin
            if (userName == "Admin1" && password == "menuliukas123")
            {
                Console.WriteLine("Admin login successful.");

                return;
            }

            // Find user in the list
            User user = users.Find(u => u.UserName == userName && u.Password == password);

            if (user != null)
            {
                Console.WriteLine("Login successful.");
                Console.WriteLine($"Welcome, {user.UserName}!");

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
    }
}

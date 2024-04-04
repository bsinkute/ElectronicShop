﻿using ElectronicShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ElectronicShop.Models
{
    public class User
    {
        DataService<User> DataService { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public int UserID { get; set; }
        public decimal Wallet { get; private set; }
        public bool IsAdmin { get; set; }
        private string _filePath = @"C:\Users\User\OneDrive\Desktop\.NET\ElectronicStore_Project\Models\users.txt";


        public string FilePath() { return _filePath; }

        public void AddToWallet(decimal amount) { Wallet += amount; }

        public void DeductFromWallet(decimal amount)
        {
            if (Wallet >= amount) { Wallet -= amount; }
            else { Console.WriteLine("Insufficient funds in the wallet.");}
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
                Console.WriteLine("Admin login successful."); return;
            }

            // Find user in the list
            User user = users.Find(u => u.Username == userName && u.Password == password);

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
            Console.WriteLine("Enter your username:");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();
            Console.WriteLine("Enter your email address:");

            do
            {
                EmailAddress = Console.ReadLine();
            } while (!IsValidEmail(EmailAddress));

            User newUser = new User { Username = userName, Password = password, EmailAddress = EmailAddress }; // Create user object

            users.Add(newUser); // Add user to list
            
            SaveUsers(users); // Save users to file

            Console.WriteLine("User registered successfully.");
        }

        public void SaveUsers(List<User> users)
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (User user in users)
                {
                    writer.WriteLine($"{user.Username},{user.Password},{user.EmailAddress},{user.Wallet}");
                }
            }
        }

        public void SaveUsersEXAMPLE()
        {
            DataService<User> dataServiceUser = new DataService<User> { FileName = "Users.json" };
            var user = dataServiceUser.ReadJson() ?? new User();


        }

        public List<User> LoadUsers()
        {
            List<User> users = new List<User>();

            if (File.Exists(_filePath))
            {
                string[] lines = File.ReadAllLines(_filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    User user = new User
                    {
                        Username = parts[0],
                        Password = parts[1],
                        EmailAddress = parts[2],
                        Wallet = decimal.Parse(parts[3]) // Load wallet balance
                    };
                    users.Add(user);
                }
            }
            return users;
        }

        public static bool IsValidEmail(string email)
        { 
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"; //regex pattern check
            return Regex.IsMatch(email, pattern);
        }
    }
}
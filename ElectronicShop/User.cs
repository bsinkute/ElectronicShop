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
    }
}

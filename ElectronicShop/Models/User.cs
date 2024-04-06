using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicShop.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public decimal Wallet { get; private set; }
        public bool IsAdmin { get; set; }

        public void AddToWallet(decimal amount) { Wallet += amount; }

        public void DeductFromWallet(decimal amount)
        {
            if (Wallet >= amount) { Wallet -= amount; }
            else { Console.WriteLine("Insufficient funds in the wallet."); }
        }

        public override string ToString()
        {
            return $"{UserId:000}. {Username}\nEmail: {EmailAddress}\nPassword: {Password}";
        }
    }
}

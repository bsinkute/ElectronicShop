using ElectronicShop.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicShop.Models
{
    public class NewUser : User
    {
        public List<User> Users { get; set; } = [];

        public override string ToString()
        {
            return $"{UserID:000}. {Username}\nEmail: {EmailAddress}\nPassword: {Password}\n";
        }

        public void SaveUser(string username, string password, string emailAddress)
        {
            int userID = Username.Any() ? Username.Max(item => item + 1) : 1;
            var newUser = new User
            { 
                UserID = userID,
                Username = username,
                Password = password,
                EmailAddress = emailAddress
            };
            Users.Add(newUser);
        }
    }
}

using ElectronicShop.Models.Interfaces;
using ElectronicShop.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicShop.Models
{
    public class NewUser : IUser
    {
        public List<User> Users { get; set; } = [];
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public int UserID { get; set; }

        public override string ToString()
        {
            return $"{UserID:000}. {Username}\nEmail: {EmailAddress}\nPassword: {Password}";
        }

        public void SaveUser(string username, string password, string emailAddress)
        {
            int userID = Users.Any() ? Users.Max(item => item.UserID) +1 : 1;
            var newUser = new User()
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

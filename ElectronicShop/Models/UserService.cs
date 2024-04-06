using ElectronicShop.Infrastructure;
using ElectronicShop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicShop.Models
{
    public class UserService : IUserService
    {
        private readonly IDataService<List<User>> _userDataService;

        public UserService(IDataService<List<User>> userDataService)
        {
            _userDataService = userDataService;
        }

        public bool SaveUser(string username, string password, string emailAddress)
        {
            var users = _userDataService.ReadJson() ?? [];
            int userID = users.Any() ? users.Max(item => item.UserId) + 1 : 1;
            var newUser = new User()
            {
                UserId = userID,
                Username = username,
                Password = password,
                EmailAddress = emailAddress
            };
            users.Add(newUser);
            _userDataService.WriteJson(users);
            return true;
        }

        public User GetUser(string userName, string password)
        {
            var users = _userDataService.ReadJson() ?? [];
            var user = users.Find(u => u.Username == userName && u.Password == password);
            return user;
        }
    }
}

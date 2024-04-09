using ElectronicShop.Infrastructure;
using ElectronicShop.Interfaces;
using ElectronicShop.Models;

namespace ElectronicShop.Services
{
    public class UserService : IUserService
    {
        private readonly IDataService<UsersData> _userDataService;
        public UserService(IDataService<UsersData> userDataService)
        {
            _userDataService = userDataService;
        }

        public void SaveUser(string username, string password)
        {
            var user = _userDataService.ReadJson() ?? new UsersData();
            user.AddUser(username, password);
            _userDataService.WriteJson(user);
        }
        public User GetUser(string username, string password)
        {
            var userData = _userDataService.ReadJson() ?? new UsersData();
            var user = userData.Users.Find(u => u.Username == username && u.Password == password);
            return user;
        }

    }
}

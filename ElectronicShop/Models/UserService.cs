using ElectronicShop.Infrastructure;
using ElectronicShop.Models.Interfaces;

namespace ElectronicShop.Models
{
    internal class UserService : IUserService
    {
        private IDataService<UsersData> _userDataService = new DataService<UsersData> { FileName = "Users.json" };
        public void SaveUser(string username, string password)
        {
            var user = _userDataService.ReadJson() ?? new UsersData();
            user.AddUser(username,password);
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

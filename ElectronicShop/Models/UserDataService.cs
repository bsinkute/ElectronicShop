using ElectronicShop.Infrastructure;
using ElectronicShop.Models.Interfaces;

namespace ElectronicShop.Models
{
    internal class UserDataService : IUserService
    {
        private IDataService<UsersData> _userDataService = new DataService<UsersData> { FileName = "Users.json" };
        public void SaveUser(string username, string password)
        {
            var user = _userDataService.ReadJson() ?? new UsersData();
            user.AddUser(username,password);
            _userDataService.WriteJson(user);
        }
        public string GetUser(string username, string password)
        {
            var user = _userDataService.ReadJson() ?? new UsersData();
            return user.ToString();
        }

    }
}

using ElectronicShop.Models.Shop;

namespace ElectronicShop.Models
{
    internal class UsersData
    {
        public List<User> Users { get; set; } = [];
        public void AddUser(string userName, string userPassword)
        {
            int userID = Users.Any() ? Users.Max(user => user.UserID) + 1 : 1;
            User user = new User
            {
                UserID = userID,
                Username = userName,
                Password = userPassword
            };
            Users.Add(user);
        }
    }
}

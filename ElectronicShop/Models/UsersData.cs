namespace ElectronicShop.Models
{
    public class UsersData
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
        
        public void UpdateUser(User newUser)
        {
            var userIndex = Users.FindIndex(user => user.UserID == newUser.UserID);
            if (userIndex == -1)
            {
                return;
            }
            Users[userIndex] = newUser;
        }

        public void RemoveUser(int userId)
        {
            var userIndex = Users.FindIndex(user => user.UserID == userId);
            if (userIndex == -1)
            {
                return;
            }
            Users.RemoveAt(userIndex);
        }
    }
}

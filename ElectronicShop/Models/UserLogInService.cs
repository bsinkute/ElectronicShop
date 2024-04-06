using ElectronicShop.Models.Interfaces;

namespace ElectronicShop.Models
{
    internal class UserLogInService : IUserLogin
    {
        public void Login()
        {
            Console.Clear();
            Console.WriteLine("User LogIn:");
            Console.WriteLine("Please enter a NickName:");
            var nickName = Console.ReadLine();
            Console.WriteLine("Please enter a password:");
            var password = Console.ReadLine();
            IPasswordService encodePsw = new PasswordService(password);
            var encryptedPassword = encodePsw.EncryptPassword();
            IUserService userService = new UserService();
            var currentUser = userService.GetUser(nickName, encryptedPassword);
            
        }
    }
}

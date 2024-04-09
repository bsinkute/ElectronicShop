using ElectronicShop.Interfaces;
using ElectronicShop.Models;
namespace ElectronicShop.Services
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserWindowService _userWindowService;
        private readonly IUserService _userService;

        public UserLoginService(IUserWindowService userWindowService, IUserService userService)
        {
            _userWindowService = userWindowService;
            _userService = userService;
        }

        public User CurrentUser { get; private set; }
        public void Login()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("User login:");
                Console.WriteLine("Please enter your nickname:");
                var nickName = Console.ReadLine();
                Console.WriteLine("Please enter your password:");
                var password = Console.ReadLine();
                IPasswordService encodePsw = new PasswordService(password);
                var encryptedPassword = encodePsw.EncryptPassword();
                var user = _userService.GetUser(nickName, encryptedPassword);
                if (user == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your nickname and password does not match any registered user");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press ENTER");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                else if (user.Username == nickName && user.Password == encryptedPassword)
                {
                    CurrentUser = user;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"You loged as ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{nickName}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($" successfully");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press ENTER");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                    _userWindowService.LoadUserWindow(CurrentUser);
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error at UserLogInService.Login");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press ENTER");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
            }
        }
    }
}

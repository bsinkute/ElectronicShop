using ElectronicShop.Models.Interfaces;
namespace ElectronicShop.Models
{
    public class UserLoginService : IUserLoginService
    {
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
                IUserService userService = new UserService();
                var user = userService.GetUser(nickName, encryptedPassword);
                if (user==null)
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
                    Console.WriteLine($"You loged as {nickName} successfully");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press ENTER");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                    UserWindowService userWindow = new UserWindowService();
                    userWindow.LoadUserWindow();
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

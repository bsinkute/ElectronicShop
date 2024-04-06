using ElectronicShop.Models.Interfaces;
namespace ElectronicShop.Models
{
    public class UserLogInService : IUserLogin
    {
        public int CurentUserID { get; set; }
        public void Login()
        {
            while (true)
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
                var user = userService.GetUser(nickName, encryptedPassword);
                if (user==null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your NickName or Password don't match according registration files");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press ENTER");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                else if (user.Username == nickName && user.Password == encryptedPassword)
                {
                    CurentUserID = user.UserID;
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
        public int UserID() { return CurentUserID; }
    }
}

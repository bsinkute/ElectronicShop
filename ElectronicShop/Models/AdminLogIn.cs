using ElectronicShop.Models.Interfaces;

namespace ElectronicShop.Models
{
    public class AdminLogin : IAdmin
    {
        private readonly IAdminWindowSelection _adminWindowSelection;

        public AdminLogin(IAdminWindowSelection adminWindowSelection)
        {
            _adminWindowSelection = adminWindowSelection;
        }

        public void Login()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Admin login");
                Console.WriteLine("Please enter your password:");
                var adminPassword = Console.ReadLine();

                if (adminPassword == "admin159")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"You have successfully logged in as ADMIN");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press ENTER");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                    _adminWindowSelection.SelectMenu();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong password");
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

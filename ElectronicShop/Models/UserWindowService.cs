using ElectronicShop.Models.Interfaces;
namespace ElectronicShop.Models
{
    internal class UserWindowService : IUserWindowService
    {
        public void LoadUserWindow()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("User Window");
                Console.WriteLine("1. User Settings \n2. Cart Review \n3. Go To Shop \n4. LogOut");
                bool isCorectSelection = int.TryParse(Console.ReadLine(), out int userWindowSelection);
                if (!isCorectSelection || userWindowSelection < 1 || userWindowSelection > 4)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Next time enter number from 1 to 4");
                    Console.ResetColor();
                    Console.ReadLine();
                    continue;
                }
                else if (isCorectSelection && userWindowSelection >= 1 && userWindowSelection <= 4)
                {
                    UserWindowSelector(userWindowSelection);
                }
                else Console.WriteLine("Error at LoadUserWindow");
            }
        }
        public void UserWindowSelector(int selectionFromUserWindow)
        {
            switch (selectionFromUserWindow)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("User Settings--- Method");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Cart--- Method");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Go To Shop--- Method");
                    break;
                case 4:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You Loged Out");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press ENTER");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                    ILoadShop loadShop = new LoadShopService();
                    loadShop.Load();
                    break;
                default:
                    Console.WriteLine("Error at UserWindowSelector");
                    break;
            }
        }
    }
}

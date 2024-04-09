using ElectronicShop.Infrastructure;
using ElectronicShop.Models;
using ElectronicShop.Models.Shop;

namespace ElectronicShop
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            var usersDataService = new DataService<UsersData> { FileName = "Users.json" };
            var inventoryDataService = new DataService<Inventory> { FileName = "Inventory.json" };
            var balanceService = new BalanceService(usersDataService);
            var userWindowService = new UserWindowService(usersDataService, inventoryDataService, balanceService);
            var userService = new UserService(usersDataService);
            var userLoginService = new UserLoginService(userWindowService, userService);
            var adminWindowSelection = new AdminWindowSelection(inventoryDataService, usersDataService);
            var adminLogin = new AdminLogin(adminWindowSelection);
            var userSignUp = new UserSignUpService(userService);
            var loadShopService = new LoadShopService(userLoginService, adminLogin, userSignUp);
            
            loadShopService.Load();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Thank you for shopping with us!");
            Console.ResetColor();
        }
    }
}
    


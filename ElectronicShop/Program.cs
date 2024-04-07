using ElectronicShop.Infrastructure;
using ElectronicShop.Models;
using ElectronicShop.Models.Shop;
namespace ElectronicShop
{
    public class Program
    {
        static void Main(string[] args)
        {
            var usersDataService = new DataService<UsersData> { FileName = "Users.json" };
            var inventoryDataService = new DataService<Inventory> { FileName = "Inventory.json" };
            var balanceService = new BalanceService(usersDataService);
            var userWindowService = new UserWindowService(usersDataService, inventoryDataService, balanceService);
            var userLoginService = new UserLoginService(userWindowService);
            var loadShopService = new LoadShopService(userLoginService);
            var adminService = new AdminWindowSelection(inventoryDataService, usersDataService);

            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            loadShopService.Load();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You Colosed the program");
            Console.ResetColor();
        }
    }
}
    


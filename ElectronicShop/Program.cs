using ElectronicShop.Infrastructure;
using ElectronicShop.Models;
using ElectronicShop.Models.Shop;
namespace ElectronicShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Hello, World!");
            /*UserWindow userWindow = new UserWindow();
            UserWindowSelection selection = new UserWindowSelection();
            userWindow.LoadUserWindow(out int userWindowSelection);
            selection.Selecter(userWindowSelection);
            UserSettingsWindow userSettingsWindow = new UserSettingsWindow();
            UserSettingsSelecter userSettingsSelecter = new UserSettingsSelecter();
            userSettingsWindow.LoadUserSettingsWindow(out int userSettingsSelection);
            userSettingsSelecter.UserSettingsWindowSelecter(userSettingsSelection);*/
            IDataService<Inventory> readDataService = new DataService<Inventory> { FileName = "Inventory.json" };
            UserShop userShop1 = new UserShop(readDataService);
            userShop1.UserShoping();
            IDataService<Cart> writeDataService = new DataService<Cart> { FileName = "Users Cart Items.json" };
            UserShop userShop2 = new UserShop(writeDataService);
            userShop2.WriteCatrDataToJson();
            //userShop.WriteCatrDataToJson();
        }
    }
}
    


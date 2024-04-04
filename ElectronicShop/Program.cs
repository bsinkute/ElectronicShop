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
            /*Console.WriteLine("Hello, World!");
            Console.WriteLine("Hello, World!");
            UserWindow userWindow = new UserWindow();
            UserWindowSelection selection = new UserWindowSelection();
            userWindow.LoadUserWindow(out int userWindowSelection);
            selection.Selecter(userWindowSelection);
            UserSettingsWindow userSettingsWindow = new UserSettingsWindow();
            UserSettingsSelecter userSettingsSelecter = new UserSettingsSelecter();
            userSettingsWindow.LoadUserSettingsWindow(out int userSettingsSelection);
            userSettingsSelecter.UserSettingsWindowSelecter(userSettingsSelection);*/
            //AddNewItem();
            UserShop userShop = new UserShop();
            userShop.UserShoping();
            userShop.WriteCatrDataToJson();
        }
        public static void AddNewItem()
        {
            DataService<Inventory> dataService = new DataService<Inventory> { FileName = "Inventory.json" };
            var inventory = dataService.ReadJson() ?? new Inventory();

            Console.Write("Enter Item Name: ");
            var name = Console.ReadLine();
            var isValidName = !string.IsNullOrWhiteSpace(name);
            while (!isValidName)
            {
                name = Console.ReadLine();
                isValidName = !string.IsNullOrWhiteSpace(name);
            }

            Console.Write("Enter Item Description: ");
            var description = Console.ReadLine();
            var isValidDescription = !string.IsNullOrWhiteSpace(description);
            while (!isValidDescription)
            {
                description = Console.ReadLine();
                isValidDescription = !string.IsNullOrWhiteSpace(description);
            }

            Console.Write("Enter Item Price: ");
            var isValidPrice = decimal.TryParse(Console.ReadLine(), out decimal price);
            while (!isValidPrice || price <= 0)
            {
                Console.Write("ERROR: Please enter positive number: ");
                isValidPrice = decimal.TryParse(Console.ReadLine(), out price);
            }

            Console.Write("Enter Item Quantity: ");
            var isValidQuantity = int.TryParse(Console.ReadLine(), out int quantity);
            while (!isValidQuantity || quantity <= 0)
            {
                Console.Write("ERROR: Please enter positive number: ");
                isValidQuantity = int.TryParse(Console.ReadLine(), out quantity);
            }

            inventory.AddItem(name, description, price, quantity);
            dataService.WriteJson(inventory);
        }
    }
}
    


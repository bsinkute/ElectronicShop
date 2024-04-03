using ElectronicShop.Infrastructure;
using ElectronicShop.Models.Shop;

namespace ElectronicShop.Models
{
    internal class AdminWindowSelection
    {
        public void Selector(int selectionFromAdminWindow)
        {
            switch (selectionFromAdminWindow)
            {
                case 1:
                    Console.Clear();
                    AddNewItem();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Edit Item--- Method");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("User Review--- Method");
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Delete User--- Method");
                    break;
                case 5:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You Loged Out");
                    Console.ResetColor();
                    Console.WriteLine("Shop Load--- Method");
                    break;
                default:
                    Console.WriteLine("ERROR");
                    break;
            }
        }

        private void AddNewItem()
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
            while(!isValidDescription)
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

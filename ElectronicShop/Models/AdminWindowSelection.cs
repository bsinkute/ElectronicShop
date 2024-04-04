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
                    EditItem();
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

            Console.WriteLine("Item added successfully.");
        }

        private void EditItem()
        {
            DataService<Inventory> dataService = new DataService<Inventory> { FileName = "Inventory.json" };
            var inventory = dataService.ReadJson() ?? new Inventory();

            Console.WriteLine("Enter the ID of the item you want to edit:");
            if (!int.TryParse(Console.ReadLine(), out int itemId))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer ID.");
                return;
            }

            var itemToEdit = inventory.Items.FirstOrDefault(item => item.Id == itemId);
            if (itemToEdit == null)
            {
                Console.WriteLine($"Item with ID {itemId} not found in inventory.");
                return;
            }

            Console.WriteLine($"Editing item with ID {itemId}:");

            Console.Write("Enter new Item Name (press Enter to keep current): ");
            var newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
                itemToEdit.Name = newName;

            Console.Write("Enter new Item Description (press Enter to keep current): ");
            var newDescription = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newDescription))
                itemToEdit.Description = newDescription;

            Console.Write("Enter new Item Price (press Enter to keep current): ");
            var newPriceInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newPriceInput) && decimal.TryParse(newPriceInput, out decimal newPrice) && newPrice > 0)
                itemToEdit.Price = newPrice;

            Console.Write("Enter new Item Quantity (press Enter to keep current): ");
            var newQuantityInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newQuantityInput) && int.TryParse(newQuantityInput, out int newQuantity) && newQuantity > 0)
                itemToEdit.Quantity = newQuantity;

            dataService.WriteJson(inventory);

            Console.WriteLine("Item updated successfully.");

        }

        
    }
}

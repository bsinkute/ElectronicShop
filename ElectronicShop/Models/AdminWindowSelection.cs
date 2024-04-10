using ElectronicShop.Infrastructure;
using ElectronicShop.Interfaces;

namespace ElectronicShop.Models
{
    internal class AdminWindowSelection : IAdminWindowSelection
    {
        private readonly IDataService<Inventory> _inventoryDataService;
        private readonly IDataService<UsersData> _userDataService;

        public AdminWindowSelection(IDataService<Inventory> inventoryDataService, IDataService<UsersData> userDataService)
        {
            _inventoryDataService = inventoryDataService;
            _userDataService = userDataService;
        }

        public void SelectMenu()
        {
            var adminWindow = new AdminWindow();
            adminWindow.LoadAdminSettingsWindow(out int selectionFromAdminWindow);
            while (selectionFromAdminWindow != 5)
            {
                Choise(selectionFromAdminWindow);
                adminWindow.LoadAdminSettingsWindow(out selectionFromAdminWindow);
            }
        }

        private void Choise(int selectionFromAdminWindow)
        {
            Console.Clear();
            switch (selectionFromAdminWindow)
            {
                case 1:
                    AddNewItem();
                    break;
                case 2:
                    EditItem();
                    break;
                case 3:
                    UserReview();
                    Console.ReadLine();
                    break;
                case 4:
                    DeleteUser();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have to choose a number between 1 and 4");
                    Console.Clear();
                    break;
            }
        }

        private void AddNewItem()
        {
            var inventory = _inventoryDataService.ReadJson() ?? new Inventory();

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
            _inventoryDataService.WriteJson(inventory);

            Console.WriteLine("Item added successfully.");
        }

        private void EditItem()
        {

            var inventory = _inventoryDataService.ReadJson() ?? new Inventory();

            Console.WriteLine("Current shop items:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(inventory);
            Console.ResetColor();

            Console.Write("Enter the ID of the item you want to edit: ");
            if (!int.TryParse(Console.ReadLine(), out int itemId))
            {
                Console.Write("Invalid input. Please enter a valid integer ID: ");
                return;
            }

            var itemToEdit = inventory.Items.FirstOrDefault(item => item.Id == itemId);
            if (itemToEdit == null)
            {
                Console.WriteLine($"Item with ID {itemId:000} not found in inventory.");
                return;
            }

            Console.WriteLine($"Editing item with ID {itemId:000}:");

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

            _inventoryDataService.WriteJson(inventory);

            Console.WriteLine("Item updated successfully.");
        }

        private UsersData UserReview()
        {
            try
            {
                var users = _userDataService.ReadJson() ?? new UsersData();

                if (users == null || users.Users.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No users found.");
                    Console.ResetColor();
                    return users;
                }

                Console.WriteLine("Users:");
                foreach (var user in users.Users)
                {
                    Console.WriteLine(user);
                }

                return users;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
                return null;
            }
        }

        private void DeleteUser()
        {
            try
            {
                var users = UserReview();

                if (users == null || users.Users.Count == 0)
                {
                    return;
                }

                Console.Write("Enter user id that should be deleted: ");
                var parseSuccess = int.TryParse(Console.ReadLine(), out int userIdToDelete);
                while (!parseSuccess || !users.Users.Any(user => user.UserID == userIdToDelete))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (!parseSuccess)
                    {
                        Console.Write("Please enter a valid integer: ");
                    }
                    else if (!users.Users.Any(user => user.UserID == userIdToDelete))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("User not found. Enter user id, from the list above: ");
                        Console.ResetColor();
                    }
                    Console.ResetColor();
                    parseSuccess = int.TryParse(Console.ReadLine(), out userIdToDelete);
                }

                users.RemoveUser(userIdToDelete);
                _userDataService.WriteJson(users);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("User with an id ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(userIdToDelete.ToString("000"));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" has been deleted.");
                Console.ResetColor();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}

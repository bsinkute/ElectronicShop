using ElectronicShop.Infrastructure;
using ElectronicShop.Models.Shop;

namespace ElectronicShop.Models
{
    internal class CartWindow
    {
        private readonly IDataService<UsersData> _userDataService;
        private readonly IDataService<Inventory> _inventoryDataService;

        public CartWindow(IDataService<UsersData> userDataService, IDataService<Inventory> inventoryDataService)
        {
            _userDataService = userDataService;
            _inventoryDataService = inventoryDataService;
        }
        
        public void UserCartReview(User user)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Items in Your Cart:");
                var cart = user.Cart;
                foreach (var item in cart.CartItems)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.Write($"Total Cart Price: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(cart.TotalPrice().ToString("N") + " €");
                Console.ResetColor();
                Console.WriteLine("1. Payment");
                Console.WriteLine("2. Go Back");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter number from 1 to 2: ");
                Console.ResetColor();
                bool isCorectSelection = int.TryParse(Console.ReadLine(), out int selectionFromUserCart);
                if (!isCorectSelection || selectionFromUserCart < 1 || selectionFromUserCart > 2)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Next time enter number from 1 to 2");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press ENTER");
                    Console.ResetColor();
                    Console.ReadLine();
                    continue;
                }
                else if (selectionFromUserCart == 1)
                {
                    ProcessPayment(user);
                    break;
                }
                else
                {
                    break;
                }
            }
        }

        public void ProcessPayment(User user)
        {
            var inventory = _inventoryDataService.ReadJson() ?? new Inventory();
            var validCart = new Cart();
            foreach (var cartItem in user.Cart.CartItems)
            {
                var inventoryItem = inventory.Items.FirstOrDefault(item => item.Id == cartItem.InCartItemID);
                if (inventoryItem == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Item not found in the inventory. It will be taken out of the cart.");
                    Console.ResetColor();
                }
                else if (inventoryItem.Quantity < cartItem.InCartItemQuantity)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not enough items in the inventory. It will be taken out of the cart.");
                    Console.ResetColor();
                }
                else
                {
                    validCart.CartItems.Add(cartItem);
                }
            }

            if (user.TryDeduceMoney(validCart.TotalPrice()))
            {
                foreach (var cartItem in user.Cart.CartItems)
                {
                    var itemIndex = inventory.Items.FindIndex(item => item.Id == cartItem.InCartItemID);
                    inventory.Items[itemIndex].Quantity -= cartItem.InCartItemQuantity;
                }

                user.Cart.CartItems.Clear();

                _inventoryDataService.WriteJson(inventory);
                SaveUser(user);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Items purchased successfully! Press ENTER to continue shopping.");
                Console.ResetColor();
                Console.ReadLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Insufficient funds to buy these items");
                Console.ResetColor();
                Console.Write($"You need at least");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($" {validCart.TotalPrice() - user.Balance:N} € ");
                Console.ResetColor();
                Console.WriteLine($"more.");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Press ENTER");
                Console.ResetColor();
                Console.ReadLine();
            }
        }

        public void SaveUser(User user)
        {
            var userData = _userDataService.ReadJson() ?? new UsersData();
            userData.UpdateUser(user);
            _userDataService.WriteJson(userData);
        }
    }
}

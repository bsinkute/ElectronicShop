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
                Console.WriteLine(cart.TotalPrice() + "€");
                Console.ResetColor();
                Console.WriteLine("1. Payment");
                Console.WriteLine("2. Go Back");
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
                    Console.WriteLine("Item not found in the inventory. It will be taken out of the cart.");
                }
                else if (inventoryItem.Quantity < cartItem.InCartItemQuantity)
                {
                    Console.WriteLine("Not enough items in the inventory. It will be taken out of the cart.");
                }
                else
                {
                    validCart.CartItems.Add(cartItem);
                }
            }

            if (user.TryDeduceMoney(validCart.TotalPrice()))
            {
                user.Cart.CartItems.Clear();

                foreach (var cartItem in user.Cart.CartItems)
                {
                    var inventoryItem = inventory.Items.First(item => item.Id == cartItem.InCartItemID);
                    inventoryItem.Quantity -= cartItem.InCartItemQuantity;
                }

                _inventoryDataService.WriteJson(inventory);
                SaveUser(user);
                Console.WriteLine("Items purchased successfully! Press ENTER to continue shopping.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Insufficient funds to buy these items");
                Console.WriteLine($"You need at least {validCart.TotalPrice() - user.GetBalance():N} € more.");
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

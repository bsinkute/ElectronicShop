using ElectronicShop.Infrastructure;
using ElectronicShop.Models;
namespace ElectronicShop.Services
{
    public class UserShopService
    {
        private readonly IDataService<UsersData> _userDataService;
        private readonly IDataService<Inventory> _inventoryDataService;

        public UserShopService(IDataService<UsersData> userDataService, IDataService<Inventory> inventoryDataService)
        {
            _userDataService = userDataService;
            _inventoryDataService = inventoryDataService;
        }

        public void UserShoping(User user)
        {
            var itemAddToCart = new Cart();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Go Shoping");
                Console.WriteLine("Insert Item Id. to Add to Your Cart \nQ. Go Back");
                var shopItems = _inventoryDataService.ReadJson() ?? new Inventory();
                if (shopItems == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: SHOP ITEMS RETURNED AS NULL");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press ENTER");
                    Console.ResetColor();
                    Console.ReadLine();
                    break;
                }
                foreach (var item in shopItems.Items)
                {
                    var itemToAdd = itemAddToCart.CartItems.FirstOrDefault(cartItem => cartItem.InCartItemID == item.Id);
                    var itemInUserCart = user.Cart.CartItems.FirstOrDefault(cartItem => cartItem.InCartItemID == item.Id);
                    item.Quantity -= itemInUserCart?.InCartItemQuantity ?? 0;
                    item.Quantity -= itemToAdd?.InCartItemQuantity ?? 0;
                    Console.WriteLine(item.ToString());
                }
                string shopSelection = Console.ReadLine().ToLower().ToString();
                if (string.IsNullOrEmpty(shopSelection) || string.IsNullOrWhiteSpace(shopSelection))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Insert Q to go back or Item Nr. if You whant add it to Your Cart");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press ENTER");
                    Console.ResetColor();
                    Console.ReadLine();
                    continue;
                }
                else if (shopSelection == "q")
                {
                    user.Cart = itemAddToCart;
                    var usersData = _userDataService.ReadJson() ?? new UsersData();
                    usersData.UpdateUser(user);
                    _userDataService.WriteJson(usersData);
                    break;
                }
                else if (shopItems.Items.Any(item => item.Id == Convert.ToInt32(shopSelection)))
                {
                    Item selectedItem = shopItems.Items.First(item => item.Id == Convert.ToInt32(shopSelection));
                    itemAddToCart.AddToUserCart(selectedItem);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Item Added to Your Cart");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press ENTER");
                    Console.ResetColor();
                    Console.ReadLine();
                    continue;
                }
                else if (shopItems.Items.Any(item => item.Id != Convert.ToInt32(shopSelection)))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input does not match the Item Nr.");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press ENTER");
                    Console.ResetColor();
                    Console.ReadLine();
                    continue;
                }
            }
        }
    }
}

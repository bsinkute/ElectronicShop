using ElectronicShop.Infrastructure;
using ElectronicShop.Models.Shop;
namespace ElectronicShop.Models
{
    internal class UserShopService
    {
        private readonly IDataService<Inventory> _inventoryDataService;
        public UserShopService(IDataService<Inventory> inventoryDataService) 
        {
            _inventoryDataService = inventoryDataService;
        }
        public IDataService<Cart> writeData = new DataService<Cart> { FileName = "Users Cart Items.json" };
        public void UserShoping()
        {
            var itemAddToCart = new Cart();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Go Shoping");
                Console.WriteLine("Insert Item Nr.to Add to Your Cart \nQ. Go Back");
                var shopItems = _inventoryDataService.ReadJson() ?? new Inventory();
                if(shopItems == null) { Console.WriteLine("ERROR: SHOP ITEMS RETURNED AS NULL"); break; }
                foreach (var item in shopItems.Items)
                {
                    Console.WriteLine($"Item Nr.: {item.Id}, {item.Name},Description: {item.Description}, Price: {item.Price}€");
                }
                string shopSelection = Console.ReadLine().ToLower().ToString();
                //string pattern = "\\d{3}";//>>>> paterna greiciausia teks trinti
                //bool isMatch = Regex.IsMatch(shopSelection, pattern);// >>>>patikrinima greiciausia teks trinti
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
                    writeData.WriteJson(itemAddToCart);
                    break;
                }
                else if (shopItems.Items.Any(item => item.Id == Convert.ToInt32(shopSelection)))//>>> isMatch && greiciausia teks trinti
                {
                    Item selectedItem = shopItems.Items.First(item => item.Id == Convert.ToInt32(shopSelection));
                    itemAddToCart.AddToUserCart(selectedItem) ;
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

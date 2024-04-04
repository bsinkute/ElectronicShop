using ElectronicShop.Infrastructure;
using ElectronicShop.Models.Interfaces;
using ElectronicShop.Models.Shop;

namespace ElectronicShop.Models
{
    internal class UserShop: ICart
    {
        
        private readonly IDataService<Inventory> _inventoryDataService;
        public UserShop(IDataService<Inventory> inventoryDataService) 
        {
            _inventoryDataService = inventoryDataService;
        }
        private readonly IDataService<Cart> _cartDataService;
        public UserShop(IDataService<Cart> cartDataService) 
        {
            _cartDataService = cartDataService;
        }



        //public List<Item> ShopItems { get; set; } = new List<Item>();
        public List<Cart> UserCart { get; set; } =new List<Cart>();

        public void UserShoping()//out int shopSelection
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Go Shoping");
                Console.WriteLine("Insert Item Nr.to Add to Your Cart \nQ. Go Back");
                /*DataService<List<Item>> readJson = new DataService<List<Item>> { FileName = "Inventory.json" };
                ShopItems = readJson.ReadJson();*/

                var ShopItems = _inventoryDataService.ReadJson() ?? new Inventory();


                if(ShopItems == null) { Console.WriteLine("ERROR: SHOP ITEMS RETURNED AS NULL"); break; }
                foreach (var item in ShopItems.Items)
                {
                    Console.WriteLine($"Item Nr.: {item.Id}, {item.Name},Description: {item.Description}, Price: {item.Price}€");
                }
                string shopSelection = Console.ReadLine().ToLower().ToString();
                //string pattern = "\\d{3}";//>>>> paterna greiciausia teks trinti
                //bool isMatch = Regex.IsMatch(shopSelection, pattern);// >>>>patikrinima greiciausia teks trinti
                if (string.IsNullOrEmpty(shopSelection) || string.IsNullOrWhiteSpace(shopSelection))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Insert Q or Item Nr.if You whant add it to Your Cart");
                    Console.ResetColor();
                    continue;
                }
                else if (shopSelection == "q")
                {
                    break;
                }
                else if (ShopItems.Items.Any(item => item.Id == Convert.ToInt32(shopSelection)))//>>> isMatch && greiciausia teks trinti
                {
                    Item selectedItem = ShopItems.Items.First(item => item.Id == Convert.ToInt32(shopSelection));
                    
                    var itemAddToCart = new Cart();
                    itemAddToCart.AddToUserCart(selectedItem);
                    //_cartDataService.WriteJson(itemAddToCart);
                    Console.WriteLine("Item Added to Your Cart");
                    Console.ReadLine();
                    continue;
                }
                else
                {
                    Console.WriteLine("Input does not match the Item Nr.");
                    continue;
                }
            }
        }
        public void WriteCatrDataToJson() 
        {
            var itemAddToCart = new Cart();
            _cartDataService.WriteJson(itemAddToCart);

            /*DataService<List<Cart>> writeJson  = new DataService<List<Cart>> { FileName = "Users Cart Items.json" };
            writeJson.WriteJson(UserCart);*/
        }

        

    }
}

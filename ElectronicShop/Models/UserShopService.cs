using ElectronicShop.Infrastructure;
using ElectronicShop.Models.Interfaces;
using ElectronicShop.Models.Shop;
using System.Collections.Generic;

namespace ElectronicShop.Models
{
    internal class UserShopService//: ICart
    {
        //public List<Cart> UserCart { get; set; }

        private readonly IDataService<Inventory> _inventoryDataService;
        public UserShopService(IDataService<Inventory> inventoryDataService) 
        {
            _inventoryDataService = inventoryDataService;
        }
        /*private readonly IDataService<Cart> _cartDataService;
        public UserShopService(IDataService<Cart> cartDataService) 
        {
            _cartDataService = cartDataService;
        }*/



        //public List<Item> ShopItems { get; set; } = new List<Item>();
        

        public void UserShoping()//out int shopSelection
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Go Shoping");
                Console.WriteLine("Insert Item Nr.to Add to Your Cart \nQ. Go Back");
                /*DataService<List<Item>> readJson = new DataService<List<Item>> { FileName = "Inventory.json" };
                ShopItems = readJson.ReadJson();*/
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
                    break;
                }

                //<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>
                
                else if (shopItems.Items.Any(item => item.Id == Convert.ToInt32(shopSelection)))//>>> isMatch && greiciausia teks trinti
                {
                    Item selectedItem = shopItems.Items.First(item => item.Id == Convert.ToInt32(shopSelection));
                    
                    var itemAddToCart = new Cart();
                    itemAddToCart.AddToUserCart(selectedItem);
                    //_cartDataService.WriteJson(itemAddToCart.UserCart);
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
        /*public void WriteCatrDataToJson() 
        {
            
            //_cartDataService.WriteJson();

            
        }*/

        

    }
}

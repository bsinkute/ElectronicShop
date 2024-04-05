using ElectronicShop.Infrastructure;
using ElectronicShop.Models.Shop;
using System;
namespace ElectronicShop.Models
{
    public class Cart
    {
        public int UserID { get; set; } = 3;
        public int InCartItemID { get; set; }
        public string InCartItemName { get; set; }
        public string InCartItemDescription { get; set; }   
        public decimal InCartItemPrice { get; set; }
        public int InCartItemQuantity { get; set; }
        public List<Cart> Carts { get; set; } = [];

        public IDataService<Cart> writeData = new DataService<Cart> { FileName = "Users Cart Items.json" };
        /*public Cart(IDataService<Cart> cartDataService)
        {
        _cartDataService = cartDataService;
        }*/
        
        
        public void AddToUserCart(Item item)
        {
            Cart cartItem = new Cart
            {
                UserID = UserID,
                InCartItemID = item.Id,
                InCartItemName = item.Name,
                InCartItemDescription = item.Description,
                InCartItemPrice = item.Price,
                InCartItemQuantity = item.Quantity,
            };
            Carts.Add(cartItem);
            
            
            writeData.WriteJson(cartItem);                    
            

        }

        /*public void WriteCatrDataToJson()
        {
            
            //_cartDataService.WriteJson(UserCart); //{ FileName = "Users Cart Items.json" };

            
        }*/

    }
}

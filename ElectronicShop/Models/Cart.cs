using ElectronicShop.Models.Shop;
using System;
namespace ElectronicShop.Models
{
    public class Cart
    {
        public int UserID { get; set; }
        public int InCartItemID { get; set; }
        public string InCartItemName { get; set; }
        public decimal InCartItemPrice { get; set; }
        public int InCartItemQuantity { get; set; }
        
        public List<Cart> UserCart { get; set; } = new List<Cart>(); 
        public void AddToUserCart(Item item)
        {
            Cart cartItem = new Cart
            {
                UserID = UserID,
                InCartItemID = item.Id,
                InCartItemName = item.Name,
                InCartItemPrice = item.Price,
                InCartItemQuantity = item.Quantity,
            };
            UserCart.Add(cartItem);
        }
        
    }
}

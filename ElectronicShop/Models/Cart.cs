using ElectronicShop.Models.Shop;
namespace ElectronicShop.Models
{
    public class Cart
    {
        public List<CartItem> CartItems { get; set; } = [];
        public void AddToUserCart(Item item)
        {
            CartItem cartItem = new CartItem
            {
                UserID =66,// Apjungiant reikės pakeisti 66 Į CURRENT USER
                InCartItemID = item.Id,
                InCartItemName = item.Name,
                InCartItemDescription = item.Description,
                InCartItemPrice = item.Price,
                InCartItemQuantity = item.Quantity,
            };
            CartItems.Add(cartItem);
        }
    }
}

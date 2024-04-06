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
                InCartItemID = item.Id,
                InCartItemName = item.Name,
                InCartItemDescription = item.Description,
                InCartItemPrice = item.Price,
                InCartItemQuantity = item.Quantity,
            };
            CartItems.Add(cartItem);
        }

        public decimal TotalPrice()
        {
            return CartItems.Sum(x => x.InCartItemPrice);
        }
    }
}

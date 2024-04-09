namespace ElectronicShop.Models
{
    public class Cart
    {
        public List<CartItem> CartItems { get; set; } = [];
        public void AddToUserCart(Item item)
        {
            var itemAlreadyInCart = CartItems.FirstOrDefault(cartItem => cartItem.InCartItemID == item.Id);

            if (itemAlreadyInCart == null)
            {
                CartItem cartItem = new CartItem
                {
                    InCartItemID = item.Id,
                    InCartItemName = item.Name,
                    InCartItemDescription = item.Description,
                    InCartItemPrice = item.Price,
                    InCartItemQuantity = 1,
                };
                CartItems.Add(cartItem);
            }
            else
            {
                itemAlreadyInCart.InCartItemQuantity++;
            }
        }

        public decimal TotalPrice()
        {
            return CartItems.Sum(x => x.InCartItemPrice * x.InCartItemQuantity);
        }
    }
}

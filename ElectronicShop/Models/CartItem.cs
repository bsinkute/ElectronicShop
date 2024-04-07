namespace ElectronicShop.Models
{
    public class CartItem
    {
        public int UserID { get; set; }
        public int InCartItemID { get; set; }
        public string InCartItemName { get; set; }
        public string InCartItemDescription { get; set; }
        public decimal InCartItemPrice { get; set; }
        public int InCartItemQuantity { get; set; }

        public override string ToString()
        {
            return $"Item Id.: {InCartItemID:000}, {InCartItemName}, Description: {InCartItemDescription}, Price: {InCartItemPrice:N} €, Qty: {InCartItemQuantity}";
        }
    }
}

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
    }
}

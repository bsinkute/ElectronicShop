using ElectronicShop.Models.Shop;
namespace ElectronicShop.Models
{
    public class Cart
    {
        public int UserID { get; set; }
        
        public List<Cart> UserCart { get; set; } = new List<Cart>();
        
    }
}

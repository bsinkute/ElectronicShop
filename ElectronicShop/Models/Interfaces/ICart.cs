using ElectronicShop.Models.Shop;

namespace ElectronicShop.Models.Interfaces
{
    public interface ICart
    {
        List<Cart> UserCart { get; set; }
    }
}

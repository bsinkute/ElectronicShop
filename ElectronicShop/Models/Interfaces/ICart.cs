using ElectronicShop.Models.Shop;

namespace ElectronicShop.Models.Interfaces
{
    public interface ICart
    {
        List<Item> UserCart { get; set; }
    }
}

using ElectronicShop.Models;

namespace ElectronicShop.Interfaces
{
    public interface IBalanceService
    {
        void AddBalance(User user, decimal amount);
    }
}

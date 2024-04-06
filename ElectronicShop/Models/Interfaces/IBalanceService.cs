namespace ElectronicShop.Models.Interfaces
{
    public interface IBalanceService
    {
        void AddBalance(User user, decimal amount);
    }
}

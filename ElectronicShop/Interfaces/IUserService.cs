using ElectronicShop.Models;

namespace ElectronicShop.Interfaces
{
    public interface IUserService
    {
        void SaveUser(string username, string password);
        User GetUser(string username, string password);
    }
}

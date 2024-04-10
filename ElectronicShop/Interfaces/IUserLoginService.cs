using ElectronicShop.Models;

namespace ElectronicShop.Interfaces
{
    public interface IUserLoginService
    {
        public User CurrentUser { get; }
        void Login();
    }
}

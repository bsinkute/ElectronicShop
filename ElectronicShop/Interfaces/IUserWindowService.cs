using ElectronicShop.Models;

namespace ElectronicShop.Interfaces
{
    public interface IUserWindowService
    {
        void LoadUserWindow(User user);
        void UserWindowSelector(int selectionFromUserWindow, User user);
    }
}

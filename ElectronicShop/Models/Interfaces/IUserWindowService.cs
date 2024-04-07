namespace ElectronicShop.Models.Interfaces
{
    public interface IUserWindowService
    {
        void LoadUserWindow(User user);
        void UserWindowSelector(int selectionFromUserWindow, User user);
    }
}

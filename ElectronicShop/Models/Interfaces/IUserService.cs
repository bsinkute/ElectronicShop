namespace ElectronicShop.Models.Interfaces
{
    public interface IUserService
    {
        void SaveUser(string username, string password);
        string GetUser(string username, string password);
    }
}

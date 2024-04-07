namespace ElectronicShop.Models.Interfaces
{
    public interface IUserLoginService
    {
        public User CurrentUser { get; }
        void Login();
    }
}

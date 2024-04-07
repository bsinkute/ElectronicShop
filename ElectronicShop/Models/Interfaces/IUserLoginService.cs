namespace ElectronicShop.Models.Interfaces
{
    internal interface IUserLoginService
    {
        public User CurrentUser { get; }
        void Login();
    }
}

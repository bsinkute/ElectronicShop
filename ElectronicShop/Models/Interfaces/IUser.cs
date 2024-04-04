namespace ElectronicShop.Models.Interfaces
{
    public interface IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public int UserID { get; set; }
    }
}

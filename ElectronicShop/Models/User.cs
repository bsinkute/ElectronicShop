namespace ElectronicShop.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserID { get; set; }
        public Cart Cart { get; set; } = new Cart();
        public decimal Balance { get; set; }

        public void AddBalance(decimal amount)
        {
            if (amount < 0)
            {
                return;
            }
            Balance += amount;
        }

        public bool TryDeduceMoney(decimal amount)
        {
            if (Balance - amount < 0)
            {
                return false;
            }
            Balance -= amount;
            return true;
        }
    }
}

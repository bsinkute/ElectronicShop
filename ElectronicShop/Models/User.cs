namespace ElectronicShop.Models
{
    public class User
    {
        private decimal _balance;

        public string Username { get; set; }
        public string Password { get; set; }
        public int UserID { get; set; }
        public Cart Cart { get; set; } = new Cart();

        public decimal GetBalance()
        {
            return _balance;
        }

        public void AddBalance(decimal amount)
        {
            if (amount < 0)
            {
                return;
            }
            _balance += amount;
        }

        public bool TryDeduceMoney(decimal amount)
        {
            if (_balance - amount < 0)
            {
                return false;
            }
            _balance -= amount;
            return true;
        }
    }
}

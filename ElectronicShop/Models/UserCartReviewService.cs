using ElectronicShop.Infrastructure;
using ElectronicShop.Models.Shop;
using static System.Collections.Specialized.BitVector32;

namespace ElectronicShop.Models
{
    internal class UserCartReviewService
    {
        
        public decimal TotalPrice { get; set; }
        private readonly IDataService<Cart> _cartDataService;
        public UserCartReviewService(IDataService<Cart> cartDataServiceDataService)
        {
            _cartDataService = cartDataServiceDataService;
        }
        //public IDataService<Cart> _cartDataService = new DataService<Cart> { FileName = "Users Cart Items.json" };<<< Šitą kolkas palikti. Kai yra šita eilutė nereikia padavinėti per konstruktorių. Kai bendrai apjunginėsime, tikriausia reikės tokiu būdu visur padavinėti.
        public void UserCartReview()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Items in Your Cart:");
                var catrItems = _cartDataService.ReadJson() ?? new Cart();//Čia nuskaitomas krepšelis bendras visai programai, tačiau krepšelis turėtų būti individualus kiekvienam klientui. Tam reikėtų panaudoti User klasę, nors ji kol kas dar neegzistuoja.
                foreach (var cart in catrItems.CartItems)
                {
                    Console.WriteLine($"Item Nr.: {cart.InCartItemID}, {cart.InCartItemName},Description: {cart.InCartItemDescription}, Price: {cart.InCartItemPrice}€".ToString());
                    TotalPrice += TotalPrice + cart.InCartItemPrice;
                }
                Console.Write($"Total Cart Price: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(TotalPrice+ "€");
                Console.ResetColor();
                Console.WriteLine("1. Payment \r\n2. Go To User Window");
                bool isCorectSelection = int.TryParse(Console.ReadLine(), out int selectionFromUserCart);
                if (!isCorectSelection || selectionFromUserCart < 1 || selectionFromUserCart > 2)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Next time enter number from 1 to 2");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press ENTER");
                    Console.ResetColor();
                    Console.ReadLine();
                    continue;
                }
                else if(selectionFromUserCart==1 || selectionFromUserCart== 2)
                {
                    ReviewSelect(selectionFromUserCart);
                    break;
                }
                else break;
            }
        }
        public void ReviewSelect(int slection)
        {
            switch (slection)
            {
                case 1:
                    Console.WriteLine("Payment--- Method");
                    break;
                case 2: 
                    UserWindowService userWindow = new UserWindowService();
                    userWindow.LoadUserWindow(out int non);
                    break;
                default: 
                    Console.WriteLine("ERROR from UserCartReviewService.ReviewSelect");
                    break ;
            }
        }
    }
}

using ElectronicShop.Infrastructure;
using ElectronicShop.Models.Shop;

namespace ElectronicShop.Models
{
    internal class UserCartReview
    {
        public int UserID { get; set; }
        public decimal TotalPrice { get; set; }
        public List<string> UserCartItems { get; set; } = new List<string>();

        public void UserCart(out int selectionFromUserCart)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Cart Review:");
                DataService<string> readUserCartData = new DataService<string> { FileName = "Users Cart Items.json" };
                var readedData = readUserCartData.ReadJson();

                foreach (var item in readedData)
                {
                    /*if ()
                    {

                    }*/
                    Console.WriteLine($"");
                }

                Console.WriteLine("1. Payment \r\n2. Go To User Windowt");
                bool isCorectSelection = int.TryParse(Console.ReadLine(), out selectionFromUserCart);
                if (!isCorectSelection || selectionFromUserCart < 1 || selectionFromUserCart > 2)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Next time enter number from 1 to 2");
                    Console.ResetColor();
                    Console.ReadLine();
                    continue;
                }
                else break;
            }
        }
    }
}

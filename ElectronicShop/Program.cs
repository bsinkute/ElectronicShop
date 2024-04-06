using ElectronicShop.Models;
using ElectronicShop.Models.Interfaces;
namespace ElectronicShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            ILoadShop loadShop = new LoadShopService();
            loadShop.Load();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You Colosed the program");
            Console.ResetColor();
        }
    }
}
    


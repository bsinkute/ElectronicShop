using ElectronicShop.Models;

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
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Hello, World!");
            UserWindow userWindow = new UserWindow();
            userWindow.LoadUserWindow(out int  userWindowSelection);
            switch (userWindowSelection)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("User Settings--- Method");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Cart--- Method");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Go To Shop--- Method");
                    break;
                case 4:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You Loged Out");
                    Console.ResetColor();
                    Console.WriteLine("Shop Load--- Method");
                    break;
                default:
                    Console.WriteLine("ERROR");
                    break;

            }
        }
    }
}

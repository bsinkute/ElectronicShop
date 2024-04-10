namespace ElectronicShop.Models
{
    internal class UserWindow
    {
        public void LoadUserWindow(out int userWindowSelection)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("User Window");
                Console.WriteLine("1. User Settings \n2. Cart Review \n3. Go To Shop \n4. LogOut");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter number from 1 to 4: ");
                Console.ResetColor();
                bool isCorectSelection = int.TryParse(Console.ReadLine(), out userWindowSelection);
                if (!isCorectSelection || userWindowSelection < 1 || userWindowSelection > 4)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Next time enter number from 1 to 4");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press ENTER");
                    Console.ResetColor();
                    Console.ReadLine();
                    continue;
                }
                else break;
                
            }
        }
    }
}

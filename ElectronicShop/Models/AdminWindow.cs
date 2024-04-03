namespace ElectronicShop.Models
{
    public class AdminWindow
    {
        public void LoadAdminSettingsWindow(out int adminSettingsSelection)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Admin Window:");
                Console.WriteLine("1. Add New Item \r\n2. Edit Item \r\n3. User Review \r\n4. Delete User \r\n5. Log Out");
                bool isCorectSelection = int.TryParse(Console.ReadLine(), out adminSettingsSelection);
                if (!isCorectSelection || adminSettingsSelection < 1 || adminSettingsSelection > 5)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Next time enter number from 1 to 5");
                    Console.ResetColor();
                    Console.ReadLine();
                    continue;
                }
                else break;
            }
        }
    }
}

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
            AdminWindow adminWindow = new AdminWindow();
            AdminWindowSelection adminWindowSelection = new AdminWindowSelection();

            int adminSettingsSelection;
            adminWindow.LoadAdminSettingsWindow(out adminSettingsSelection);

            adminWindowSelection.Selector(adminSettingsSelection);

            Console.ReadLine();


            /*UserWindow userWindow = new UserWindow();
            UserWindowSelection selection = new UserWindowSelection();
            userWindow.LoadUserWindow(out int userWindowSelection);
            selection.Selecter(userWindowSelection);
            UserSettingsWindow userSettingsWindow = new UserSettingsWindow();
            UserSettingsSelecter userSettingsSelecter = new UserSettingsSelecter();
            userSettingsWindow.LoadUserSettingsWindow(out int userSettingsSelection);
            userSettingsSelecter.UserSettingsWindowSelecter(userSettingsSelection);*/
        }
        
    }
}

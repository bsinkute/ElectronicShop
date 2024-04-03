namespace ElectronicShop.Models
{
    internal class AdminWindowSelection
    {
        public void Selector(int selectionFromAdminWindow)
        {
            switch (selectionFromAdminWindow)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Add New Item--- Method");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Edit Item--- Method");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("User Review--- Method");
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Delete User--- Method");
                    break;
                case 5:
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

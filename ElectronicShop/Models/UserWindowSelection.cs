namespace ElectronicShop.Models
{
    internal class UserWindowSelection 
    {
        public void Selecter(int selectionFromUserWindow)
        {
            switch (selectionFromUserWindow)
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

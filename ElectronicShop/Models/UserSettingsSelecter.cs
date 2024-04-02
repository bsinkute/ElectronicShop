namespace ElectronicShop.Models
{
    internal class UserSettingsSelecter
    {
        public void UserSettingsWindowSelecter(int selectionFromUserSelection)
        {
            switch (selectionFromUserSelection)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Balance Overwiew--- Method");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Add Balance--- Method");
                    break;
                default:
                    Console.WriteLine("ERROR");
                    break;
            }
        }
    }
}

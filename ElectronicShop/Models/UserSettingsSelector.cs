using ElectronicShop.Interfaces;

namespace ElectronicShop.Models
{
    internal class UserSettingsSelector
    {
        private readonly IBalanceService _balanceService;

        public UserSettingsSelector(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        public void UserSettingsWindowSelecter(int selectionFromUserSelection, User user)
        {
            switch (selectionFromUserSelection)
            {
                case 1:
                    Console.Clear();
                    Console.Write("Your balance is: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(user.Balance.ToString("N") + " €");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press ENTER");
                    Console.ResetColor();
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("How much money would you like to add?");
                    var isValidAmount = decimal.TryParse(Console.ReadLine(), out decimal amountToAdd);
                    while (!isValidAmount)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR: Amount entered is not a valid number");
                        Console.ResetColor();
                        Console.Write("Please try again: ");
                        isValidAmount = decimal.TryParse(Console.ReadLine(), out amountToAdd);
                    }
                    _balanceService.AddBalance(user, amountToAdd);
                    Console.Clear();
                    Console.WriteLine($"Successfully added {amountToAdd:N} € to your balance.");
                    Console.WriteLine($"Your new balance is {user.Balance:N} €");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press ENTER");
                    Console.ResetColor();
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("ERROR");
                    break;
            }
        }
    }
}

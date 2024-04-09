using ElectronicShop.Infrastructure;
using ElectronicShop.Models.Interfaces;
using ElectronicShop.Models.Shop;
namespace ElectronicShop.Models
{
    public class UserWindowService : IUserWindowService
    {
        private readonly IDataService<UsersData> _userDataService;
        private readonly IDataService<Inventory> _inventoryDataService;
        private readonly IBalanceService _balanceService;

        public UserWindowService(IDataService<UsersData> userDataService, 
            IDataService<Inventory> inventoryDataService,
            IBalanceService balanceService)
        {
            _userDataService = userDataService;
            _inventoryDataService = inventoryDataService;
            _balanceService = balanceService;
        }

        public void LoadUserWindow(User user)
        {
            while (true)
            {
                Console.Clear();
                Console.Write($"You are logged in as user: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(user.Username);
                Console.ResetColor();
                Console.WriteLine("User Window");
                Console.WriteLine("1. User Settings \n2. Cart Review \n3. Go To Shop \n4. LogOut");
                bool isCorectSelection = int.TryParse(Console.ReadLine(), out int userWindowSelection);
                if (!isCorectSelection || userWindowSelection < 1 || userWindowSelection > 4)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Next time enter number from 1 to 4");
                    Console.ResetColor();
                    Console.ReadLine();
                    continue;
                }
                else if (isCorectSelection && userWindowSelection >= 1 && userWindowSelection <= 4)
                {
                    UserWindowSelector(userWindowSelection, user);
                    if (userWindowSelection == 4)
                    {
                        break;
                    }
                }
                else Console.WriteLine("Error at LoadUserWindow");
            }
        }
        public void UserWindowSelector(int selectionFromUserWindow, User user)
        {
            Console.Clear();
            switch (selectionFromUserWindow)
            {
                case 1:
                    var userSettingsWindow = new UserSettingsWindow();
                    userSettingsWindow.LoadUserSettingsWindow(out int userSettingSelection);
                    var userSettingsSelection = new UserSettingsSelector(_balanceService);
                    userSettingsSelection.UserSettingsWindowSelecter(userSettingSelection, user);
                    break;
                case 2:
                    var cartWindow = new CartWindow(_userDataService, _inventoryDataService);
                    cartWindow.UserCartReview(user);
                    break;
                case 3:
                    var userShopService = new UserShopService(_userDataService, _inventoryDataService);
                    userShopService.UserShoping(user);
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You Loged Out");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press ENTER");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Error at UserWindowSelector");
                    break;
            }
        }
    }
}

using ElectronicShop.Models.Interfaces;

namespace ElectronicShop.Models
{
    public class LoadShopService : ILoadShop
    {
        private readonly IUserLoginService _userLoginService;
        private readonly IAdmin _adminLogin;

        public LoadShopService(IUserLoginService userLoginService, IAdmin adminLogin)
        {
            _userLoginService = userLoginService;
            _adminLogin = adminLogin;
        }
        public void Load()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. SignUp User \n2. LogIn User \n3. Login Admin \n4. Exit");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter number from 1 to 4: ");
                Console.ResetColor();
                Console.WriteLine("1. Signup User \n2. Login User \n3. Login Admin \n4. Exit");
                bool isLoadCorect= int.TryParse(Console.ReadLine(),out int loadSelect);
                if (!isLoadCorect || loadSelect < 1 || loadSelect > 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter numbers from 1 to 4");
                    Console.ResetColor();
                    continue;
                }
                else if (isLoadCorect && loadSelect >= 1 && loadSelect <= 3)
                {
                    LoadShopSelector(loadSelect);
                }
                else if (isLoadCorect && loadSelect == 4) break;
                
            }
        }
        public void LoadShopSelector(int loadSelect) 
        { 
            switch (loadSelect)
            {
                case 1:
                    IUserSignUp userSignUp = new UserSignUpService();
                    userSignUp.SignUp();
                    break;
                case 2:
                    _userLoginService.Login();
                    break;
                case 3:
                    _adminLogin.Login();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error at LoadShopSelector");
                    Console.ResetColor();
                    break;
            }
        }
    }
}

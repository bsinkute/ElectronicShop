using ElectronicShop.Models.Interfaces;

namespace ElectronicShop.Models
{
    public class LoadShopService : ILoadShop
    {
        private readonly IUserLoginService _userLoginService;

        public LoadShopService(IUserLoginService userLoginService)
        {
            _userLoginService = userLoginService;
        }
        public LoadShopService() { }

        public void Load()
        {
            while (true)
            {
                Console.WriteLine("1. SignUp User \n2. LogIn User \n3. Login Admin \n4. Exit");
                bool isLoadCorect= int.TryParse(Console.ReadLine(),out int loadSelect);
                if (!isLoadCorect || loadSelect < 1 || loadSelect > 4)
                {
                    Console.WriteLine("Please enter numbers from 1 to 4");
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
                    //Admin login
                    break;
                default:
                    Console.WriteLine("Error at LoadShopSelector");
                    break;
            }
        }
    }
}

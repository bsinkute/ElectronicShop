using ElectronicShop.Models.Interfaces;

namespace ElectronicShop.Models
{
    internal class LoadShopService : ILoadShop
    {
        //1. SignUp User 2. LogIn User 3. Login Admin 4. Exit

        public void Load()// sioje vietoje (out int loadSelect) kur daryti SWITCH
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
                else if (isLoadCorect || loadSelect >= 1 && loadSelect <= 3)
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
                    //Login
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

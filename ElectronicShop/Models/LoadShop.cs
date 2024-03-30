using ElectronicShop.Models.Interfaces;

namespace ElectronicShop.Models
{
    internal class LoadShop : ILoadShop
    {
        //1. SignUp User 2. LogIn User 3. Login Admin 4. Exit

        void ILoadShop.LoadShop(out int loadSelect)// sioje vietoje (out int loadSelect) kur daryti SWITCH
        {
            while (true)
            {
                Console.WriteLine("1. SignUp User \n2. LogIn User \n3. Login Admin \n4. Exit");
                bool isLoadCorect= int.TryParse(Console.ReadLine(),out  loadSelect);
                if (!isLoadCorect || loadSelect < 1 || loadSelect > 4)
                {
                    Console.WriteLine("Please enter numbers from 1 to 4");
                    continue;
                }
                else if (isLoadCorect && loadSelect == 4) Console.WriteLine("You Colosed the program"); break;
                
            }
        }
    }
}

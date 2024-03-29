
namespace ElectronicShop.Models.Interfaces
{
    public interface ILoadShop
    {
        //cia metodas su tikslu >> pirmam pasirinkimui 1. Signup User 2. LogIn User 3. Login Admin 4. Exit
        // Admin sukursime paciame viduje per private field AdminPassword
        void LoadShop(out int loadSelect);
    }
}

using System.Security.Cryptography.X509Certificates;

namespace ElectronicShop.Models.Interfaces
{
    public interface IPasswordService
    {
        string EncryptPassword();
        string DecryptPassword(string encryptedPassword);
    }
}

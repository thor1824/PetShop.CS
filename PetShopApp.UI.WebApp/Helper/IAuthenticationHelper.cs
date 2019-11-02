using PetShopApp.Core.Entity;

namespace PetShopApp.UI.WebApp.Helper
{
    public interface IAuthenticationHelper
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        string GenerateToken(User user);
        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
    }
}
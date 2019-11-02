using PetShopApp.Core.Entity;

namespace PetShopApp.Core.ApplicationService
{
    public interface ILoginService
    {
        User Login(string username);

    }
}

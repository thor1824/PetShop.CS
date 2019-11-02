using PetShop.Infrastructure.DataWithEntity;

namespace PetShopApp.UI.WebApp
{
    public interface IDbSeeder
    {
        void Seed(PetShopAppContext ctx);
    }
}
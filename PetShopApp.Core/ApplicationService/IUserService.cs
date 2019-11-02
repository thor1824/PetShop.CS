using PetShopApp.Core.Entity;
using System.Collections.Generic;

namespace PetShopApp.Core.ApplicationService.Impl
{
    public interface IUserService
    {
        User Create(User user);

        User Read(int id);

        List<User> ReadAll();

        User Update(User user);

        User Delete(int id);


    }
}
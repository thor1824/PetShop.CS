using System.Collections.Generic;
using PetShopApp.Core.Entity;

namespace PetShopApp.Core.ApplicationService
{
    public interface ISpeciesService
    {
        Species Create(Species species);
        Species Delete(int id);
        Species Read(long id);
        List<Species> ReadAll();
        Species Update(Species species);
    }
}
using System.Collections.Generic;
using PetShopApp.Core.Entity;
using PetShopApp.Core.Entity.Enum;

namespace PetShopApp.Core.ApplicationService
{
    public interface IPetService
    {
        Pet CreatePet(Pet pet);
        Pet DeletePet(int id);
        List<Pet> ReadAllPet();
        Pet ReadPetByID(int id);
        Pet UpdatePet(Pet pet);
        List<Pet> SeachByType(PetType.PType type);
        SortedList<int, PetType.PType> getPetTypeInSortedList();
        List<Pet> ReadAllByCheapest();

    }
}
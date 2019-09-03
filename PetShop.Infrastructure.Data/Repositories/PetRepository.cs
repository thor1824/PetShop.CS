using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using PetShop.Infrastructure.Data.MockDB;
using System.Linq;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class PetRepository : IRepository<Pet>
    {
        public Pet Create(Pet entity)
        {
            entity.Id = TestDB.GetFirstAvailablePetID();
            TestDB.pets.Add(entity);
            return entity;
        }

        public Pet Read(int id)
        {
            return TestDB.GetPetsInDB().First(p => p.Id == id);
        }

        public IEnumerable<Pet> ReadAll()
        {
            return TestDB.GetPetsInDB();
        }

        public Pet Update(Pet entity)
        {
            for (int i = 0; i < TestDB.GetPetsInDB().ToList().Count; i++)
            {
                if (TestDB.pets[i].Id.Equals(entity.Id))
                {
                    TestDB.pets[i] = entity;
                    return entity;
                }
            }
            return null;
        }

        public Pet Delete(Pet pet)
        {
            TestDB.pets.Remove(pet);
            return pet;
        }
    }
}

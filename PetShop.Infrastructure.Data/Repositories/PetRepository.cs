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
            entity.Id = TestDB.GetFirstAvailableID();
            TestDB.pets.Add(entity);
            return entity;
        }
        public Pet Read(int id)
        {

            foreach (Pet petFromDB in TestDB.GetPetsInDB())
            {
                if (petFromDB.Id.Equals(id))
                {
                    return petFromDB;
                }
            }
            return null;
        }
        public IEnumerable<Pet> ReadAll()
        {
            return TestDB.GetPetsInDB();
        }
        public Pet Update(Pet entity)
        {
            for (int i = 0; i < TestDB.GetPetsInDB().ToList().Count; i++)
            {
                if (TestDB.GetPetsInDB().ToList()[i].Id.Equals(entity.Id))
                {
                    TestDB.GetPetsInDB().ToList()[i] = entity;
                    return entity;
                }
            }
            return null;
        }
        public Pet Delete(int id)
        {

            Pet pet = TestDB.GetPetsInDB().First(p => p.Id == id);
            TestDB.pets.Remove(pet);
            return pet;
        }
    }
}

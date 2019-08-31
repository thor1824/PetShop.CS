using PetShop.Infrastructure.Data.MockDB;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IRepository<Owner>
    {
        public Owner Create(Owner entity)
        {
            entity.Id = TestDB.GetFirstAvailableOwnerID();
            TestDB.owners.Add(entity);
            return entity;
        }

        public Owner Read(int id)
        {
            return TestDB.GetOwnersInDB().First(pet => pet.Id == id);
        }

        public IEnumerable<Owner> ReadAll()
        {
            return TestDB.GetOwnersInDB().ToList();
        }

        public Owner Update(Owner entity)
        {
            Owner owner = TestDB.GetOwnersInDB().First(pet => pet.Id == entity.Id);
            owner = entity;
            return owner;
        }

        public Owner Delete(Owner entity)
        {
            TestDB.owners.Remove(entity);
            return entity;
        }
    }
}

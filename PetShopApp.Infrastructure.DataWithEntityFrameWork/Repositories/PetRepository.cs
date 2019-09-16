using Microsoft.EntityFrameworkCore;
using PetShop.Infrastructure.DataWithEntity;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp.Infrastructure.DataWithEntityFrameWork.Repositories
{
    public class PetRepository : IRepository<Pet>
    {
        private readonly PetShopAppContext _ctx;

        public PetRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }

        public Pet Create(Pet entity)
        {
            return _ctx.Pets.Add(entity).Entity;
        }

        public Pet Delete(Pet entity)
        {
            _ctx.Pets.Remove(entity).State = EntityState.Deleted;
            return _ctx.SaveChanges() == 1 ? null : entity;
        }

        public Pet Read(long id)
        {
            return _ctx.Pets.Include(pet => pet.PriviousOwner).FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Pet> ReadAll()
        {
            return _ctx.Pets.Include(pet => pet.PriviousOwner).ToList();
        }

        public Pet Update(Pet entity)
        {
            var result = Read(entity.Id.Value);
            if (result != null)
            {
                result.Name = entity.Name;
                result.PType = entity.PType;
                result.BirthDate = entity.BirthDate;
                result.SoldDate = entity.SoldDate;
                result.Color = entity.Color;
                result.PriviousOwner = entity.PriviousOwner;
                result.Price = entity.Price;
                _ctx.SaveChanges();
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PetShop.Infrastructure.DataWithEntity;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System.Collections.Generic;
using System.Linq;

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
            Pet pet = _ctx.Pets.Add(entity).Entity;
            _ctx.SaveChanges();
            return pet;
        }

        public Pet Delete(Pet entity)
        {
            _ctx.Pets.Remove(entity).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return entity;
        }

        public Pet Read(long id)
        {
            return _ctx.Pets
                .Include(pet => pet.PreviousOwners)
                .ThenInclude(e => e.Owner)
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Pet> ReadAll()
        {
            return _ctx.Pets
                .Include(pet => pet.Species)
                .Include(pet => pet.PreviousOwners)
                .ThenInclude(p => p.Owner)
                .ToList();
        }

        public Pet Update(Pet entity)
        {
            var result = Read(entity.Id.Value);
            if (result != null)
            {
                result.Name = entity.Name;
                result.Species = entity.Species;
                result.BirthDate = entity.BirthDate;
                result.SoldDate = entity.SoldDate;
                result.Color = entity.Color;
                result.PreviousOwners = entity.PreviousOwners;
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

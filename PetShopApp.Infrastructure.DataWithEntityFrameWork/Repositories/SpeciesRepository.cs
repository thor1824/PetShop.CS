using Microsoft.EntityFrameworkCore;
using PetShop.Infrastructure.DataWithEntity;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShopApp.Infrastructure.SQL.Repositories
{
    public class SpeciesRepository : IRepository<Species>
    {
        private readonly PetShopAppContext _ctx;

        public SpeciesRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }

        public Species Create(Species entity)
        {
            Species species = _ctx.Species.Add(entity).Entity;
            _ctx.SaveChanges();
            return species;
        }

        public Species Delete(Species entity)
        {
            _ctx.Species.Remove(entity).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return entity;
        }

        public Species Read(long id)
        {
            return _ctx.Species.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Species> ReadAll()
        {
            return _ctx.Species;
        }

        public Species Update(Species entity)
        {
            var result = Read(entity.Id);
            if (result != null)
            {
                result.Name = entity.Name;
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

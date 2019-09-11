using PetShop.Infrastructure.DataWithEntity;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp.Infrastructure.DataWithEntityFrameWork.Repositories
{
    class PetRepository : IRepository<Pet>
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
            throw new NotImplementedException();
        }

        public Pet Read(int id)
        {
            return _ctx.Pets.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Pet> ReadAll()
        {
            return _ctx.Pets;
        }

        public Pet Update(Pet entity)
        {
            throw new NotImplementedException();
        }
    }
}

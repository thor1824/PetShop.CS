using PetShop.Infrastructure.DataWithEntity;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp.Infrastructure.DataWithEntityFrameWork.Repositories
{
    public class OwnerRepository : IRepository<Owner>
    {
        private readonly PetShopAppContext _ctx;

        public OwnerRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }

        public Owner Create(Owner entity)
        {
            return _ctx.Owners.Add(entity).Entity;
        }

        public Owner Delete(Owner entity)
        {
            throw new NotImplementedException();
        }

        public Owner Read(int id)
        {
            return _ctx.Owners.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Owner> ReadAll()
        {
            return _ctx.Owners;
        }

        public Owner Update(Owner entity)
        {
            throw new NotImplementedException();
        }
    }
}

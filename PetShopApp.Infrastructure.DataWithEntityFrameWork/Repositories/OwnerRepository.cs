using Microsoft.EntityFrameworkCore;
using PetShop.Infrastructure.DataWithEntity;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System.Collections.Generic;
using System.Linq;

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
            _ctx.Owners.Attach(entity).State = EntityState.Added;
            _ctx.SaveChanges();
            return entity;
        }

        public Owner Delete(Owner entity)
        {
            _ctx.Owners.Remove(entity).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return entity;
        }

        public Owner Read(long id)
        {
            return _ctx.Owners
                .Include(o => o.PreviousOwnedPets)
                .ThenInclude(po => po.Pet)
                .FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Owner> ReadAll()
        {
            return _ctx.Owners
                .Include(o => o.PreviousOwnedPets)
                .ThenInclude(po => po.Pet)
                .ToList();
        }

        public Owner Update(Owner entity)
        {
            var result = _ctx.Owners.SingleOrDefault(o => o.Id == entity.Id);
            if (result != null)
            {
                result.FirstName = entity.FirstName;
                result.LastName = entity.LastName;
                result.Address = entity.Address;
                result.Email = entity.Email;
                result.PhoneNumber = entity.PhoneNumber;
                result.PreviousOwnedPets = entity.PreviousOwnedPets;
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

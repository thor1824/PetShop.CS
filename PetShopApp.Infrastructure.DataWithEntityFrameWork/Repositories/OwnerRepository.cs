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

            return _ctx.SaveChanges() == 1 ? null : entity;
        }

        public Owner Delete(Owner entity)
        {
            _ctx.Owners.Remove(entity).State = EntityState.Deleted;
            return _ctx.SaveChanges() == 1 ? null : entity;
           
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
            var result = _ctx.Owners.SingleOrDefault(o => o.Id == entity.Id);
            if (result != null)
            {
                result.FirstName = entity.FirstName;
                result.LastName = entity.LastName;
                result.Address = entity.Address;
                result.Email = entity.Email;
                result.PhoneNumber = entity.PhoneNumber;
                return _ctx.SaveChanges() == 1 ? null : result;
            }
            else
            {
                return null;
            }
        }
    }
}

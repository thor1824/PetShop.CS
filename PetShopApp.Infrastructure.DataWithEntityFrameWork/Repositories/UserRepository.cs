using Microsoft.EntityFrameworkCore;
using PetShop.Infrastructure.DataWithEntity;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp.Infrastructure.SQL.Repositories
{
    class UserRepository : IRepository<User>
    {
        private readonly PetShopAppContext _ctx;

        public UserRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }

        public User Create(User entity)
        {
            User user = _ctx.Users.Add(entity).Entity;
            _ctx.SaveChanges();
            return user;
        }

        public User Delete(User entity)
        {
            _ctx.Users.Remove(entity).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return entity;
        }

        public User Read(long id)
        {
            return _ctx.Users.FirstOrDefault(p => p.id == id);
        }

        public IEnumerable<User> ReadAll()
        {
            return _ctx.Users.ToList();
        }

        public User Update(User entity)
        {
            var result = Read(entity.id);
            if (result != null)
            {
                result.Username = entity.Username;
                result.Password = entity.Password;
                result.IsAdmin = entity.IsAdmin;
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

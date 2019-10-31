using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp.Core.ApplicationService.Impl
{
    class UserService : IUserService
    {
        private readonly IRepository<User> _repo;

        public UserService(IRepository<User> repo)
        {
            _repo = repo;
        }

        #region C.R.U.D
        public User Create(User user)
        {
            return _repo.Create(user);
        }

        public User Delete(int id)
        {
            User user = Read(id);
            return _repo.Delete(user);
        }

        public User Read(int id)
        {
            return _repo.Read(id);
        }

        public List<User> ReadAll()
        {
            return _repo.ReadAll().ToList();
        }

        public User Update(User user)
        {
            return _repo.Update(user);
        }
        #endregion
    }
}

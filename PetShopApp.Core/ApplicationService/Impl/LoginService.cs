using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System.Linq;

namespace PetShopApp.Core.ApplicationService.Impl
{
    public class LoginService : ILoginService
    {
        private readonly IRepository<User> _repo;

        public LoginService(IRepository<User> repo)
        {
            _repo = repo;
        }
        public User Login(string username)
        {
            return _repo.ReadAll().FirstOrDefault(u => u.Username.ToLower() == username.ToLower());
        }
    }
}

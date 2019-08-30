using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;

namespace PetShopApp.Core.ApplicationService.Impl
{
    public class OwnerService : IOwnerService
    {
        private IRepository<Owner> ownerRepo;

        public OwnerService(IRepository<Owner> ownerRepo)
        {
            this.ownerRepo = ownerRepo;
        }

        public Owner CreateOwner(Owner owner)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOwner(int id)
        {
            throw new NotImplementedException();
        }

        public List<Owner> ReadAllOwner()
        {
            throw new NotImplementedException();
        }

        public Owner ReadOwner(int id)
        {
            throw new NotImplementedException();
        }

        public Owner UpdateOwner(Owner owner)
        {
            throw new NotImplementedException();
        }
    }
}

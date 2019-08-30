using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using PetShopApp.UI.ConsoleView.essentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.UI.ConsoleView.Actionator.OwnerActionators
{
    public class OwnerReadinator : InputAsker, IActionator
    {
        private IRepository<Owner> _repo;
        private IOwnerService ownerService;

        public OwnerReadinator(IRepository<Owner> repo)
        {
            _repo = repo;
        }

        public OwnerReadinator(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
        }

        public void go()
        {
            throw new NotImplementedException();
        }
    }
    
    
}

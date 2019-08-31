using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.ApplicationService.Impl;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using PetShopApp.UI.ConsoleView.essentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.UI.ConsoleView.Actionator.OwnerActionators
{
    public class OwnerReadAllinator : InputAsker, IActionator
    {
        private readonly IOwnerService _ownerservice;

        public OwnerReadAllinator(IOwnerService ownerservice)
        {
            _ownerservice = ownerservice;
        }

        public void go()
        {
            try
            {
                foreach (var item in _ownerservice.ReadAllOwner())
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            
            
        }
    }
}

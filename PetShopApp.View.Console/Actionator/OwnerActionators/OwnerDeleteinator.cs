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
    public class OwnerDeleteinator : InputAsker, IActionator
    {
        private readonly IOwnerService _ownerService;

        public OwnerDeleteinator(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        public void go()
        {
            bool valid = false;
            while (!valid)
            {
                try
                {
                    int input = AskForNumericInput("Enter the id of the owner you want to delete.");
                    Owner owner = _ownerService.DeleteOwner(input);
                    valid = owner != null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Could not the Delete Owner");

                }
               
            }
        }
    }
}

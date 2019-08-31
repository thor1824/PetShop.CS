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

        private IOwnerService ownerService;

        public OwnerReadinator(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
        }

        public void go()
        {
            try
            {
                int input = AskForNumericInput("Enter ID of owner:");

                Console.WriteLine(ownerService.ReadOwner(input));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

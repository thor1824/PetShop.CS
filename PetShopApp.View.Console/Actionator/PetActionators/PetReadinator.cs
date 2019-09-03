using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using PetShopApp.UI.ConsoleView.essentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.UI.ConsoleView.Actionator.PetActionators
{
    public class PetReadinator : InputAsker, IActionator
    {

        private readonly IPetService _petService;

        public PetReadinator(IPetService ownerService)
        {
            this._petService = ownerService;
        }

        public void go()
        {
            try
            {
                int input = AskForNumericInput("Enter ID of Pet:");

                Console.WriteLine(_petService.ReadPetByID(input));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

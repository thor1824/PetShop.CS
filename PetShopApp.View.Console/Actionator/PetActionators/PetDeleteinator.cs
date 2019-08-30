using PetShopApp.Core.ApplicationService;
using PetShopApp.UI.ConsoleView.essentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.UI.ConsoleView.Actionator.PetActionators
{
    public class PetDeleteinator : InputAsker, IActionator
    {
        IPetService _petService;

        public PetDeleteinator(IPetService petService)
        {
            _petService = petService;
        }

        public void go()
        {
            int id = askForNumericInput("Enter the id of the pet you want to delete:");
            _petService.DeletePet(id);
            anyKeyInput("\nPress any key to return");

        }
    }
}

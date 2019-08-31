using PetShopApp.Core.ApplicationService;
using PetShopApp.UI.ConsoleView.essentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.UI.ConsoleView.Actionator.PetActionators
{
    public class PetDeleteinator : IActionator
    {
        IPetService _petService;

        public PetDeleteinator(IPetService petService)
        {
            _petService = petService;
        }

        public void go()
        {
            try
            {
                int id = InputAsker.AskForNumericInput("Enter the id of the pet you want to delete:");
                
                Console.WriteLine("\n Pet:" + _petService.DeletePet(id) + " was Created");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

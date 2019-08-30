using PetShopApp.Core.ApplicationService;
using PetShopApp.UI.ConsoleView.essentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.UI.ConsoleView.Actionator.PetActionators
{
    public class SortByPriceinator : InputAsker, IActionator
    {
        private IPetService _service;


        public SortByPriceinator(IPetService service)
        {
            _service = service;


        }

        public void go()
        {
            foreach (var pet in _service.ReadAllPet())
            {
                Console.WriteLine(pet);

            }
            anyKeyInput("Press any key to return");
        }
    }
}

using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.Entity;
using PetShopApp.UI.ConsoleView.essentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.UI.ConsoleView.Actionator.PetActionators
{
    public class FiveCheapestPetsinator : InputAsker, IActionator
    {
        private IPetService _service;


        public FiveCheapestPetsinator(IPetService service)
        {
            _service = service;


        }

        public void go()
        {

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(_service.ReadAllByCheapest()[i]);
            }
            anyKeyInput("Press any key to return");
            
        }
    }
}

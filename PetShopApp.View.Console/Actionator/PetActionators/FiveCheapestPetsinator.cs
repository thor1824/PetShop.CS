using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.Entity;
using PetShopApp.UI.ConsoleView.essentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.UI.ConsoleView.Actionator.PetActionators
{
    public class FiveCheapestPetsinator : IActionator
    {
        private IPetService _service;


        public FiveCheapestPetsinator(IPetService service)
        {
            _service = service;


        }

        public void go()
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(_service.ReadAllByCheapest()[i]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}

using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.Entity;
using PetShopApp.UI.ConsoleView.essentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.UI.ConsoleView.Actionator.PetActionators
{
    public class ShowAllPetsinator : IActionator
    {
        private IPetService _service;


        public ShowAllPetsinator(IPetService service)
        {
            _service = service;


        }

        public void go()
        {
            try
            {
                foreach (var pet in _service.ReadAllPet())
                {
                    Console.WriteLine(pet);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

        }
    }
}

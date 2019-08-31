using PetShopApp.Core.ApplicationService;
using PetShopApp.UI.ConsoleView.essentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.UI.ConsoleView.Actionator.PetActionators
{
    public class SortByPriceinator : IActionator
    {
        private IPetService _service;


        public SortByPriceinator(IPetService service)
        {
            _service = service;


        }

        public void go()
        {
            try
            {
                foreach (var pet in _service.ReadAllByCheapest())
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

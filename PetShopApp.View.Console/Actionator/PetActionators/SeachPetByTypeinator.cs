using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.Entity;
using PetShopApp.Core.Entity.Enum;
using PetShopApp.UI.ConsoleView.essentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.UI.ConsoleView.Actionator.PetActionators
{
    public class SeachPetByTypeinator : IActionator
    {
        private IPetService _petService;

        public SeachPetByTypeinator(IPetService petService)
        {
            _petService = petService;
        }

        public void go()
        {
            try
            {
                SortedList<int, PetType.PType> types = _petService.getPetTypeInSortedList();
                foreach (var item in _petService.getPetTypeInSortedList())
                {
                    Console.WriteLine("[" + item.Key + "] - " + item.Value.ToString());
                }

                bool valid = false;
                int input = InputAsker.AskForNumericInput("Choose a type to seach by.");
                while (!valid)
                {

                    if (input < _petService.getPetTypeInSortedList().Count && input > 0)
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("There is no Type with the choosen numeric value");
                        input = InputAsker.AskForNumericInput("\nChoose a type to seach by.");
                    }

                }
                PetType.PType type = types[input];
                List<Pet> petsByType = _petService.SeachByType(type);

                Console.WriteLine("--------------------------------------------------------");
                foreach (var item in petsByType)
                {
                    Console.WriteLine(item);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

        }
    }
}

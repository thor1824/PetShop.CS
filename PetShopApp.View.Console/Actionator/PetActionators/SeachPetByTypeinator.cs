using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.Entity;
using PetShopApp.Core.Entity.Enum;
using PetShopApp.UI.ConsoleView.essentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.UI.ConsoleView.Actionator.PetActionators
{
    public class SeachPetByTypeinator : InputAsker, IActionator
    {
        private IPetService _petService;

        public SeachPetByTypeinator(IPetService petService)
        {
            _petService = petService;
        }

        public void go()
        {
            int i = 1;
            SortedList<int, PetType.PType> types = _petService.getPetTypeInSortedList();
            foreach (var item in _petService.getPetTypeInSortedList())
            {
                Console.WriteLine("[" + item.Key + "] - " + item.Value.ToString());
            }

            bool valid = false;
            int input = askForNumericInput("Choose a type to seach by.");
            while (!valid)
            {

                if (input < _petService.getPetTypeInSortedList().Count && input > 0)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("There is no Type with the choosen numeric value");
                    input = askForNumericInput("\nChoose a type to seach by.");
                }

            }
            PetType.PType type = types[input];
            List<Pet> petsByType = _petService.SeachByType(type);

            Console.WriteLine("--------------------------------------------------------");
            foreach (var item in petsByType)
            {
                Console.WriteLine(item);

            }
            anyKeyInput("\nPress any key to return");
        }
    }
}

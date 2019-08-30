using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.Entity;
using PetShopApp.UI.ConsoleView.essentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.UI.ConsoleView.Actionator.PetActionators
{
    public class PetCreateinator : InputAsker, IActionator
    {
        private IPetService _petService;

        public PetCreateinator(IPetService petService)
        {
            this._petService = petService;
        }

        public void go()
        {
            string name = askForTextInput("Enter Name, Must be more than 3 characters long:");

            foreach (var item in _petService.getPetTypeInSortedList())
            {
                Console.WriteLine("[" + item.Key + "] - " + item.Value.ToString());
            }

            int iType = askForNumericInput("Pleace select the Pet Type");

            var type = _petService.getPetTypeInSortedList()[iType];

            Console.WriteLine("Enter Birth Day:");
            int year = askForNumericInput("Enter Year:");
            int month = askForNumericInput("Enter Month:");
            int date = askForNumericInput("Enter Date:");

            DateTime bDay = new DateTime(year, month, date);

            String color = askForTextInput("Enter Color:");

            double price = askForNumericInput("Enter Price:");

            string previousOwner = askForTextInput("Enter Name of previous Owner");

            Pet newPet = new Pet {
                Name = name,
                Type = type,
                BirthDate = bDay,
                Price = price,
                PriviousOwner = previousOwner,
                Color = color
            }; 
            _petService.CreatePet(newPet);
            anyKeyInput("\nPress any key to return");
        }
    }
}

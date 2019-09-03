using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.Entity;
using PetShopApp.UI.ConsoleView.essentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.UI.ConsoleView.Actionator.PetActionators
{
    public class PetCreateinator : IActionator
    {
        private readonly IPetService _petService;
        private readonly IOwnerService _ownerService;


        public PetCreateinator(IPetService petService, IOwnerService ownerService)
        {
            this._petService = petService;
            this._ownerService = ownerService;
        }

        public void go()
        {
            try
            {
                string name = InputAsker.AskForTextInput("Enter Name, Must be more than 3 characters long:");

                foreach (var item in _petService.getPetTypeInSortedList())
                {
                    Console.WriteLine("[" + item.Key + "] - " + item.Value.ToString());
                }

                int iType = InputAsker.AskForNumericInput("Pleace select the Pet Type");

                var type = _petService.getPetTypeInSortedList()[iType];

                DateTime bDay = InputAsker.AskForDate("Enter Birth Day:");

                String color = InputAsker.AskForTextInput("Enter Color:");

                double price = InputAsker.AskForNumericInput("Enter Price:");

                Owner previousOwner = _ownerService.ReadOwner(InputAsker.AskForNumericInput("Enter id of owner"));

                Pet newPet = new Pet
                {
                    Name = name,
                    PType = type,
                    BirthDate = bDay,
                    Price = price,
                    PriviousOwner = previousOwner,
                    Color = color
                };
                Console.WriteLine("\nPet:" + _petService.CreatePet(newPet) + " was Created");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

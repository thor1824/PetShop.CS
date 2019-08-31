using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.ApplicationService.Impl;
using PetShopApp.Core.Entity;
using PetShopApp.UI.ConsoleView.essentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.UI.ConsoleView.Actionator.PetActionators
{
    public class PetUpdateinator : IActionator
    {
        private readonly IPetService _petService;
        private readonly IOwnerService _ownerService;
        private readonly int[] _validInputs = { 1, 2, 3, 4, 5, 6, 7, 9, 0 };

        public PetUpdateinator(IPetService petService, IOwnerService ownerService)
        {
            this._petService = petService;
            this._ownerService = ownerService;

        }

        public void go()
        {
            Pet pet = null;
            while (pet == null)
            {
                int id = InputAsker.AskForNumericInput("Please Enter the id of the movie you want to update.");
                pet = _petService.ReadPetByID(id);
                if (pet == null)
                {
                    Console.WriteLine(" is not a Valid ID! Try again!");
                }
            }


            bool done = false;

            while (!done)
            {
                Console.Clear();
                Console.WriteLine("Pet found: " + pet.ToString());
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine(
                    "[1] - Edit Name\n" +
                    "[2] - Edit Type\n" +
                    "[3] - Edit Birthday\n" +
                    "[4] - Edit Color\n" +
                    "[5] - Edit Price\n" +
                    "[6] - Edit Previous Owner\n" +
                    "[7] - Edit Sold Date\n" +
                    "\n[9] - Edit All\n" +
                    "[0] - done\n"
                    );
                int input;
                while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out input))
                {
                    Console.WriteLine(" is not a Valid Input! Try again!");
                }

                if (checkIfValid(input))
                {
                    switch (input)
                    {
                        case 1:
                            Console.Clear();

                            pet.Name = InputAsker.AskForTextInput("Please enter new Title:");
                            break;

                        case 2:
                            Console.Clear();

                            foreach (var item in _petService.getPetTypeInSortedList())
                            {
                                Console.WriteLine("[" + item.Key + "] - " + item.Value.ToString());
                            }
                            int iType = InputAsker.AskForNumericInput("Pleace select the Pet Type");
                            pet.Type = _petService.getPetTypeInSortedList()[iType];
                            break;

                        case 3:
                            Console.Clear();

                            pet.BirthDate = InputAsker.AskForDate("Enter Birth Day:");
                            break;

                        case 4:
                            Console.Clear();

                            pet.Color = InputAsker.AskForTextInput("Enter Color:");
                            break;

                        case 5:
                            Console.Clear();

                            pet.Price = InputAsker.AskForNumericInput("Enter Price:");
                            break;

                        case 6:
                            Console.Clear();

                            pet.PriviousOwner = _ownerService.ReadOwner(InputAsker.AskForNumericInput("Enter id of owner"));
                            break;

                        case 7:
                            Console.Clear();

                            pet.SoldDate = InputAsker.AskForDate("Enter Sold Date:");
                            break;

                        case 9:
                            Console.Clear();

                            string name = InputAsker.AskForTextInput("Enter Name, Must be more than 3 characters long:");

                            foreach (var item in _petService.getPetTypeInSortedList())
                            {
                                Console.WriteLine("[" + item.Key + "] - " + item.Value.ToString());
                            }

                            int iType2 = InputAsker.AskForNumericInput("Pleace select the Pet Type");

                            var type2 = _petService.getPetTypeInSortedList()[iType2];

                            DateTime birthDate = InputAsker.AskForDate("Enter Birth Day:");

                            String color2 = InputAsker.AskForTextInput("Enter Color:");

                            double price2 = InputAsker.AskForNumericInput("Enter Price:");

                            Owner previousOwner2 = _ownerService.ReadOwner(InputAsker.AskForNumericInput("Enter id of owner"));

                            DateTime soldDate = InputAsker.AskForDate("Enter Sold Date:");

                            pet = new Pet
                            {
                                Name = name,
                                Type = type2,
                                BirthDate = birthDate,
                                Price = price2,
                                PriviousOwner = previousOwner2,
                                Color = color2,
                                SoldDate = soldDate

                            };
                            break;

                        case 0:
                            try
                            {
                                _petService.UpdatePet(pet);
                                done = true;
                                Console.Clear();
                                Console.WriteLine("\n The Pet:\n" + pet + " \nWas succesfully Updated.");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("\n"+ e.Message);
                                Console.WriteLine("The Pet was not updated.");
                                InputAsker.anyKeyInput("Press any key to return");
                            }
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine(" is not a Valid Input! Try again!");
                }

            }

            bool checkIfValid(int input)
            {
                foreach (int validInput in _validInputs)
                {
                    if (validInput == input)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}

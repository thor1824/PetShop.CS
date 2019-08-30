using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.ApplicationService.Impl;
using PetShopApp.Core.Entity;
using PetShopApp.UI.ConsoleView.essentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.UI.ConsoleView.Actionator.PetActionators
{
    public class PetUpdateinator : InputAsker, IActionator
    {
        IPetService _petService;
        private readonly int[] _validInputs = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        public PetUpdateinator(IPetService petService)
        {
            _petService = petService;
        }

        public void go()
        {
            Pet pet = null;
            while (pet == null)
            {
                int id = askForNumericInput("Please Enter the id of the movie you want to update.");
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
                            pet.Name = askForTextInput("Please enter new Title:");
                            break;
                        case 2:
                            Console.Clear();
                            foreach (var item in _petService.getPetTypeInSortedList())
                            {
                                Console.WriteLine("[" + item.Key + "] - " + item.Value.ToString());
                            }

                            int iType = askForNumericInput("Pleace select the Pet Type");

                            pet.Type = _petService.getPetTypeInSortedList()[iType];

                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Enter Birth Day:");
                            int year = askForNumericInput("Enter Year:");
                            int month = askForNumericInput("Enter Month:");
                            int date = askForNumericInput("Enter Date:");

                            pet.BirthDate = new DateTime(year, month, date);
                            break;
                        case 4:
                            Console.Clear();
                            pet.Color = askForTextInput("Enter Color:");
                            break;
                        case 5:
                            Console.Clear();
                            pet.Price = askForNumericInput("Enter Price:");
                            break;
                        case 6:
                            Console.Clear();
                            pet.PriviousOwner = askForTextInput("Enter Name of previous Owner");
                            break;
                        case 7:
                            Console.Clear();
                            Console.WriteLine("Enter Sold Date:");
                            int sYear = askForNumericInput("Enter Year:");
                            int sMonth = askForNumericInput("Enter Month:");
                            int sDate = askForNumericInput("Enter Date:");

                            pet.SoldDate = new DateTime(sYear, sMonth, sDate);
                            break;
                        
                        case 9:
                            Console.Clear();
                            string name = askForTextInput("Enter Name, Must be more than 3 characters long:");

                            foreach (var item in _petService.getPetTypeInSortedList())
                            {
                                Console.WriteLine("[" + item.Key + "] - " + item.Value.ToString());
                            }

                            int iType2 = askForNumericInput("Pleace select the Pet Type");

                            var type2 = _petService.getPetTypeInSortedList()[iType2];

                            Console.WriteLine("Enter Birth Day:");
                            int year2 = askForNumericInput("Enter Year:");
                            int month2 = askForNumericInput("Enter Month:");
                            int date2 = askForNumericInput("Enter Date:");

                            DateTime bDay = new DateTime(year2, month2, date2);

                            String color2 = askForTextInput("Enter Color:");

                            double price2 = askForNumericInput("Enter Price:");

                            string previousOwner2 = askForTextInput("Enter Name of previous Owner");

                            Console.WriteLine("Enter Sold Date:");
                            int sYear2 = askForNumericInput("Enter Year:");
                            int sMonth2 = askForNumericInput("Enter Month:");
                            int sDate2 = askForNumericInput("Enter Date:");
                            DateTime soldDate = new DateTime(sYear2, sMonth2, sDate2);

                            pet = new Pet
                            {
                                Name = name,
                                Type = type2,
                                BirthDate = bDay,
                                Price = price2,
                                PriviousOwner = previousOwner2,
                                Color = color2,
                                SoldDate = soldDate
                                
                            };
                            break;
                        case 0:
                            if (_petService.UpdatePet(pet) == null)
                            {
                                done = true;
                                Console.WriteLine("\n The Pet:\n" + pet + " \nWas succesfully Updated.");
                                Console.WriteLine("--------------------------------------------------------");
                                anyKeyInput("Press any Key to Continue.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Bobi de bob");
                                Console.WriteLine("--------------------------------------------------------");
                                anyKeyInput("Press any Key to Continue.");
                                break;
                            }

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

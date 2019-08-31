using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using PetShopApp.UI.ConsoleView.essentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.UI.ConsoleView.Actionator.OwnerActionators
{
    public class OwnerUpdateinator : InputAsker, IActionator
    {
        private IOwnerService _ownerService;
        private readonly int[] _validInputs = { 1, 2, 3, 4, 5, 9, 0 };

        public OwnerUpdateinator(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        public void go()
        {
            Owner owner = null;
            while (owner == null)
            {
                int id = AskForNumericInput("Please Enter the id of the movie you want to update.");
                owner = _ownerService.ReadOwner(id);
                if (owner == null)
                {
                    Console.WriteLine(" is not a Valid ID! Try again!");
                }
            }


            bool done = false;
            
            while (!done)
            {
                Console.Clear();
                Console.WriteLine("Pet found: " + owner.ToString());
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine(
                    "[1] - Edit First Name\n" +
                    "[2] - Edit Last Name\n" +
                    "[3] - Edit Adress\n" +
                    "[4] - Edit Phone Number\n" +
                    "[5] - Edit Email\n" +
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
                            owner.FirstName = AskForTextInput("Enter First Name:");

                            break;
                        case 2:
                            Console.Clear();
                            owner.LastName = AskForTextInput("Enter Last Name:");

                            break;
                        case 3:
                            Console.Clear();
                            owner.Address = AskForTextInput("Enter Adress:");

                            break;
                        case 4:
                            Console.Clear();
                            owner.PhoneNumber = AskForTextInput("Enter PhoneNumber Name:");

                            break;
                        case 5:
                            Console.Clear();
                            owner.Email = AskForTextInput("Enter Email:");

                            break;
                        case 9:
                            Console.Clear();
                            string firstname = AskForTextInput("Enter First Name:");
                            string lastName = AskForTextInput("Enter Last Name:");
                            string address = AskForTextInput("Enter Adress:");
                            string phoneNumber = AskForTextInput("Enter PhoneNumber Name:");
                            string email = AskForTextInput("Enter Email:");

                            owner = new Owner
                            {
                                FirstName = firstname,
                                LastName = lastName,
                                Address = address,
                                PhoneNumber = phoneNumber,
                                Email = email
                            };

                            break;
                        case 0:
                            try
                            {
                                _ownerService.UpdateOwner(owner);
                                done = true;
                                Console.Clear();
                                Console.WriteLine("\nThe Owner: " + owner + " was Updated");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("\n"+e.Message);
                                Console.WriteLine("The Owner was not updated.");
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


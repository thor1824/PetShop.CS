using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using PetShopApp.UI.ConsoleView.essentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.UI.ConsoleView.Actionator.OwnerActionators
{
    public class OwnerCreateinator : InputAsker, IActionator
    {
        private IOwnerService _ownerService;

        public OwnerCreateinator(IOwnerService ownerService)
        {
            this._ownerService = ownerService;
        }

        public void go()
        {
            bool valid = false;
            while (!valid)
            {
                try
                {
                    string firstName = AskForTextInput("Enter First Name:");
                    string lastName = AskForTextInput("Enter Last Name:");
                    string address = AskForTextInput("Enter Adress:");
                    string phoneNumber = AskForTextInput("Enter PhoneNumber Name:");
                    string email = AskForTextInput("Enter Email:");

                    Owner owner = new Owner
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Address = address,
                        PhoneNumber = phoneNumber,
                        Email = email
                    };

                    _ownerService.CreateOwner(owner);

                    valid = true;

                    Console.WriteLine("Owner:" + owner + " was Created");
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    Console.WriteLine("Owner was not Created");
                }
            }
            
            
        }
    }
}

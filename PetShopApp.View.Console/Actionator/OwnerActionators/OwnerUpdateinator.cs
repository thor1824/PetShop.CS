﻿using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using PetShopApp.UI.ConsoleView.essentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.UI.ConsoleView.Actionator.OwnerActionators
{
    public class OwnerUpdateinatorpublic : InputAsker, IActionator
    {
        private IRepository<Owner> _repo;

        public OwnerUpdateinatorpublic(IRepository<Owner> repo)
        {
            _repo = repo;
        }

        public void go()
        {
            throw new NotImplementedException();
        }
    }
    
}


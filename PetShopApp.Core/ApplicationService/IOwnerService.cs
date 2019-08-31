using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.ApplicationService
{
    public interface IOwnerService
    {
        Owner CreateOwner(Owner owner);

        Owner ReadOwner(int id);

        List<Owner> ReadAllOwner();

        Owner UpdateOwner(Owner owner);

        Owner DeleteOwner(int id);
    }
}

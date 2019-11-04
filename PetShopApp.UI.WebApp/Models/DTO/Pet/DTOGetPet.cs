using PetShopApp.Core.Entity;
using PetShopApp.Core.Entity.Enum;
using System;
using System.Collections.Generic;

namespace PetShopApp.UI.WebApp.DTO
{
    public class DTOGetPet
    {


        public long? Id { get; set; }
        public string Name { get; set; }
        public Species Species { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? SoldDate { get; set; }
        public double? Price { get; set; }
        public string Color { get; set; }
        public ICollection<Owner> PreviousOwners { get; set; }
    }
}

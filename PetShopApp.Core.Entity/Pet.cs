using PetShopApp.Core.Entity.Enum;
using System;
using System.Collections.Generic;

namespace PetShopApp.Core.Entity
{



    public class Pet
    {
        public bool HasId { get { return Id.HasValue; } }
        public long? Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public Species Species { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? SoldDate { get; set; }
        public double? Price { get; set; }
        public string Color { get; set; }
        public ICollection<PetOwner> PreviousOwners { get; set; }

    }
}

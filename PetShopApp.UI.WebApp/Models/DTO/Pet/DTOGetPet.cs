using PetShopApp.Core.Entity;
using PetShopApp.Core.Entity.Enum;
using System;
using System.Collections.Generic;

namespace PetShopApp.UI.WebApp.DTO
{
    public class DTOGetPet
    {

        public DTOGetPet(Pet pet)
        {
            Id = pet.Id;
            Name = pet.Name;
            PType = pet.PType;
            BirthDate = pet.BirthDate;
            SoldDate = pet.SoldDate;
            Price = pet.Price;
            Color = pet.Color;
            foreach (var item in pet.PreviousOwners)
            {
                PreviousOwners.Add(item.Owner);
            }
        }

        public long? Id { get; set; }
        public string Name { get; set; }
        public PetType.PType? PType { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? SoldDate { get; set; }
        public double? Price { get; set; }
        public string Color { get; set; }
        public ICollection<Owner> PreviousOwners { get; set; }
    }
}

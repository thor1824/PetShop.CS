﻿using PetShopApp.Core.Entity;
using PetShopApp.Core.Entity.Enum;
using System;

namespace PetShopApp.UI.WebApp.DTO
{
    public class DTOUpdatePet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public Species Species { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? SoldDate { get; set; }
        public double? Price { get; set; }
        public int[] PriviousOwners { get; set; }
        public string Color { get; set; }
    }
}

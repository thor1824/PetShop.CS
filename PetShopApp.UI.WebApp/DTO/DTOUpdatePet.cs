using PetShopApp.Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopApp.UI.WebApp.DTO
{
    public class DTOUpdatePet
    {
        public string Name { get; set; }
        public PetType.PType? PType { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? SoldDate { get; set; }
        public double? Price { get; set; }
        public int[] PriviousOwners { get; set; }
        public string Color { get; set; }
    }
}

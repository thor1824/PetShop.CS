using PetShopApp.Core.Entity;
using PetShopApp.Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.Data.MockDB
{
    public class TestDB
    {
        public static List<Pet> pets;

        public static IEnumerable<Pet> GetPetsInDB()
        {
            pets.OrderBy(p => p.Id);
            return pets;
        }

        public static int GetFirstAvailableID()
        {
            int i =  1;

            foreach (Pet pet in pets)
            {
                if (pet.Id.Equals(i))
                {
                    break;
                }

                i++;
            }

            return i;
        }

        public static void InitDB()
        {
            pets = new List<Pet>();
            pets.Add(new Pet(1, "John Johnson", PetType.PType.Cat, new DateTime(2002, 1, 2), new DateTime(2003, 1, 1), "Brown", "john", 10.00));
            pets.Add(new Pet(2, "Mack Mackson", PetType.PType.Dog, new DateTime(2001, 2, 3), new DateTime(2002, 12, 27), "Red", "Mack", 20.00));
            pets.Add(new Pet(3, "Matt Mattson", PetType.PType.Cat, new DateTime(2003, 3, 4), new DateTime(2004, 9, 15), "Black", "Matt", 30.00));
            pets.Add(new Pet(4, "Forb Forbson", PetType.PType.Dog, new DateTime(2002, 4, 5), new DateTime(2007, 6, 19), "Yellow", "Forb", 40.00));
            pets.Add(new Pet(5, "Bob Bobson", PetType.PType.Cat, new DateTime(2007, 5, 6), new DateTime(2010, 2, 3), "Blue", "Bob", 50.00));
            pets.Add(new Pet(6, "Jim Jimson", PetType.PType.Dog, new DateTime(2009, 6, 7), new DateTime(2017, 8, 12), "Transparant", "Jim", 1000.00));
            pets.Add(new Pet(7, "Friedrich Wilhelm Viktor Albert", PetType.PType.Goat, new DateTime(1859, 1, 27), new DateTime(1941, 6, 9), "White", "Wilhelm Friedrich Ludwig", 2037000.00));
            
        }
    }
}

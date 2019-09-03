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
        public static List<Owner> owners;


        public static IEnumerable<Pet> GetPetsInDB()
        {
            if (pets == null)
            {
                InitDB();
            }
            pets.OrderBy(p => p.Id);
            return pets;
        }

        public static IEnumerable<Owner> GetOwnersInDB()
        {
            if (owners == null)
            {
                InitDB();
            }
            owners.OrderBy(o => o.Id);
            return owners;
        }

        public static int GetFirstAvailablePetID()
        {
            int i =  1;

            foreach (Pet pet in GetPetsInDB())
            {
                if (!pet.Id.Equals(i))
                {
                    break;
                }

                i++;
            }

            return i;
        }

        public static int GetFirstAvailableOwnerID()
        {
            int i = 1;

            foreach (Owner owner in GetOwnersInDB())
            {
                if (!owner.Id.Equals(i))
                {
                    break;
                }
                i++;
            }

            return i;
        }

        public static void InitDB()
        {
            owners = new List<Owner>();
            Owner owner1 = new Owner(1, "John Paul", "Jones", "11. BuckStreet", "88776655", "HotStuff1@topbot.com");
            Owner owner2 = new Owner(2, "John Bob", "Keyton", "12. BuckStreet", "33774455", "HotStuff2@topbot.com");
            Owner owner3 = new Owner(3, "John Jim", "Gringo", "13. BuckStreet", "11772255", "HotStuff3@topbot.com");
            Owner owner4 = new Owner(4, "Wilhelm Friedrich", "Ludwig", "13. BuckStreet", "12345678", "h_did_nuttin_rong@topbot.com");


            owners.Add(owner1);
            owners.Add(owner2);
            owners.Add(owner3);
            owners.Add(owner4);


            pets = new List<Pet>();
            pets.Add(new Pet(1, "John Johnson", PetType.PType.Cat, new DateTime(2002, 1, 2), new DateTime(2003, 1, 1), "Brown", owner1, 10.00));
            pets.Add(new Pet(2, "Mack Mackson", PetType.PType.Dog, new DateTime(2001, 2, 3), new DateTime(2002, 12, 27), "Red", null, 22.00));
            pets.Add(new Pet(3, "Matt Mattson", PetType.PType.Cat, new DateTime(2003, 3, 4), new DateTime(2004, 9, 15), "Black", owner3, 21.00));
            pets.Add(new Pet(4, "Forb Forbson", PetType.PType.Dog, new DateTime(2002, 4, 5), new DateTime(2007, 6, 19), "Yellow", null, 40.00));
            pets.Add(new Pet(5, "Bob Bobson", PetType.PType.Cat, new DateTime(2007, 5, 6), new DateTime(2010, 2, 3), "Blue", owner2, 31.00));
            pets.Add(new Pet(6, "Jim Jimson", PetType.PType.Dog, new DateTime(2009, 6, 7), new DateTime(2017, 8, 12), "Transparant", null, 1000.00));
            pets.Add(new Pet(7, "Friedrich Wilhelm Viktor Albert", PetType.PType.Goat, new DateTime(1859, 1, 27), new DateTime(1941, 6, 9), "White", owner4, 2037000.00));

        }    
    }
}

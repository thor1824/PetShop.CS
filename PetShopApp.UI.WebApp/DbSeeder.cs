using PetShop.Infrastructure.DataWithEntity;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopApp.UI.WebApp
{
    public class DbSeeder
    {
        public static void Seed(PetShopAppContext ctx)
        {
            ctx.Database.EnsureDeleted();
            if (ctx.Database.EnsureCreated())
            {
                Owner own1 = ctx.Owners.Add(new Owner()
                {
                    FirstName = "John",
                    LastName = "Johnson",
                    Address = "johnStreet 1",
                    Email = "john@email.com",
                    PhoneNumber = "88888888"
                }).Entity;
                Owner own2 = ctx.Owners.Add(new Owner()
                {
                    FirstName = "Jim",
                    LastName = "Jimson",
                    Address = "JimStreet 1",
                    Email = "Jim@email.com",
                    PhoneNumber = "77777777"
                }).Entity;
                Owner own3 = ctx.Owners.Add(new Owner()
                {
                    FirstName = "Geo",
                    LastName = "Geoson",
                    Address = "GeoStreet 1",
                    Email = "Geo@email.com",
                    PhoneNumber = "66666666"
                }).Entity;
                ctx.SaveChanges();
                ctx.Pets.Add(new Pet()
                {
                    Name = "Johnbo",
                    PType = Core.Entity.Enum.PetType.PType.Cat,
                    BirthDate = new DateTime(1999, 1, 1),
                    SoldDate = new DateTime(2000, 1, 1),
                    Color = "Brown",
                    Price = 10.0,
                    PreviousOwners = new List<PetOwner>
                    {
                        new PetOwner{ Owner = own1}, new PetOwner{ Owner = own2}, new PetOwner{ Owner = own3}
                    }
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Jimbo",
                    PType = Core.Entity.Enum.PetType.PType.Dog,
                    BirthDate = new DateTime(2001, 1, 1),
                    SoldDate = new DateTime(2002, 1, 1),
                    Color = "Black",
                    Price = 1000.0,
                    PreviousOwners = new List<PetOwner>
                    {
                        new PetOwner{ Owner = own2}, new PetOwner{ Owner = own3}
                    }
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.SaveChanges();
            }
        }
    }
}

using PetShop.Infrastructure.DataWithEntity;
using PetShopApp.Core.Entity;
using PetShopApp.UI.WebApp.Helper;
using System;
using System.Collections.Generic;

namespace PetShopApp.UI.WebApp
{
    public class DbSeeder : IDbSeeder
    {

        private readonly IAuthenticationHelper authenticationHelper;

        public DbSeeder(IAuthenticationHelper authHelper)
        {
            authenticationHelper = authHelper;
        }

        public void Seed(PetShopAppContext ctx)
        {
            ctx.Database.EnsureDeleted();
            if (ctx.Database.EnsureCreated())
            {
                string password = "1234";
                authenticationHelper.CreatePasswordHash(password, out byte[] passwordHashJoe, out byte[] passwordSaltJoe);
                authenticationHelper.CreatePasswordHash(password, out byte[] passwordHashAnn, out byte[] passwordSaltAnn);

                List<User> users = new List<User>
                {
                    new User {
                        Username = "UserJoe",
                        PasswordHash = passwordHashJoe,
                        PasswordSalt = passwordSaltJoe,
                        IsAdmin = false
                    },
                    new User {
                        Username = "AdminAnn",
                        PasswordHash = passwordHashAnn,
                        PasswordSalt = passwordSaltAnn,
                        IsAdmin = true
                    }
                };
                ctx.Users.AddRange(users);

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

                ctx.Pets.Add(new Pet()
                {
                    Name = "Johnbo1",
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
                    Name = "Jimbo2",
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
                    Name = "Geobo3",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo4",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo5",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo6",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo7",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo8",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo9",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo10",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo11",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo12",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo13",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo14",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo15",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo16",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo17",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo18",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo19",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo20",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo21",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo22",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo23",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo24",
                    PType = Core.Entity.Enum.PetType.PType.Goat,
                    BirthDate = new DateTime(2003, 1, 1),
                    SoldDate = new DateTime(2004, 1, 1),
                    Color = "Yellow",
                    Price = 10.0
                });
                ctx.Pets.Add(new Pet()
                {
                    Name = "Geobo25",
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

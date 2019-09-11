using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShopApp.Core.Entity;


namespace PetShop.Infrastructure.DataWithEntity
{
    class PetShopAppContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }

        public PetShopAppContext(DbContextOptions<PetShopAppContext> opt) : base(opt) { }


    }
}

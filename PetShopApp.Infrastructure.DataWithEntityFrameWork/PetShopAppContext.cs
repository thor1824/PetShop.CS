using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShopApp.Core.Entity;

namespace PetShop.Infrastructure.DataWithEntity
{
    public class PetShopAppContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }

        public DbSet<User> Users { get; set; } 

        public DbSet<Species> Species { get; set; }

        public PetShopAppContext(DbContextOptions<PetShopAppContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<PetOwner>()
                .HasKey(po => new { po.PetID, po.OwnerID });

            modelBuilder.Entity<PetOwner>()
                .HasOne(po => po.Pet)
                .WithMany(p => p.PreviousOwners)
                .HasForeignKey(bc => bc.PetID);
            
            modelBuilder.Entity<PetOwner>()
                .HasOne(po => po.Owner)
                .WithMany(o => o.PreviousOwnedPets)
                .HasForeignKey(po => po.OwnerID);

        }


    }
}

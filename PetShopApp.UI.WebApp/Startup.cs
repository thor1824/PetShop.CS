using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShop.Infrastructure.DataWithEntity;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.ApplicationService.Impl;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using PetShopApp.Infrastructure.DataWithEntityFrameWork.Repositories;
//using PetShopApp.Infrastructure.SQLite.Repositories;

namespace PetShopApp.UI.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PetShopAppContext>(opt => opt.UseSqlite("Data Source = PetApp.db"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<IRepository<Pet>, PetRepository>();
            services.AddScoped<IRepository<Owner>, OwnerRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IOwnerService, OwnerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetShopAppContext>();
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
                            PriviousOwner = own1,
                            Color = "Brown",
                            Price = 10.0
                        });
                        ctx.Pets.Add(new Pet()
                        {
                            Name = "Jimbo",
                            PType = Core.Entity.Enum.PetType.PType.Dog,
                            BirthDate = new DateTime(2001, 1, 1),
                            SoldDate = new DateTime(2002, 1, 1),
                            PriviousOwner = own2,
                            Color = "Black",
                            Price = 1000.0
                        });
                        ctx.Pets.Add(new Pet()
                        {
                            Name = "Geobo",
                            PType = Core.Entity.Enum.PetType.PType.Goat,
                            BirthDate = new DateTime(2003, 1, 1),
                            SoldDate = new DateTime(2004, 1, 1),
                            PriviousOwner = own3,
                            Color = "Yellow",
                            Price = 10.0
                        });
                        ctx.SaveChanges();
                    }
                    
                    
                }

                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

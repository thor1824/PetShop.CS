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
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Env { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (Env.IsDevelopment())
            {
                services.AddDbContext<PetShopAppContext>(opt => opt.UseSqlite("Data Source = PetApp.db"));
            }
            else
            {
                services.AddDbContext<PetShopAppContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            }
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddJsonOptions(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
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
                    DbSeeder.Seed(ctx);
                }

                app.UseDeveloperExceptionPage();
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetShopAppContext>();
                    DbSeeder.Seed(ctx);
                }

                app.UseHsts();
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

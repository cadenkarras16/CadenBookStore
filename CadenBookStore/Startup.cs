using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadenBookStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CadenBookStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; set; }

        public Startup (IConfiguration temp)
        {
            Configuration = temp;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();


            services.AddDbContext<BookstoreContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BookDBConnection"]);
            });

            services.AddDbContext<AppIdentityDBContext>(options =>
            options.UseSqlite(Configuration["ConnectionStrings:IdentityConnection"]));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDBContext>();

            services.AddScoped<IBookProjectRepository, EFBookProjectRepository>();
            services.AddScoped<IBookCartRepository, EFBookCartRepository>();

            services.AddRazorPages();

            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddScoped<Basket>(x => SessionBasket.GetBasket(x));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddServerSideBlazor();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //use the files in the wwwroot folder
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "categorypage",
                    pattern: "{bookCategory}/Page{pageNum}",
                    defaults: new { Controller = "Home", Action = "Index", pageNum = 1}
                    );

                //paging one
                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "Page{pageNum}",
                    defaults: new { Controller = "Home", Action = "Index", pageNum = 1 }
                    );


                //Category one
                endpoints.MapControllerRoute("category",
                    "{bookCategory}",
                    new { Controller = "Home", action = "Index", pageNum = 1 }
                    );


                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();

                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");
            });

            IdentitySeedData.EnsurePopulated(app);
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PornApp.DAL;
using PornApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PornApp
{
    public class Startup
    {
        /// <summary>
        /// https://app.pluralsight.com/course-player?clipId=b87b2d3c-820a-4301-964b-9c51758a87a1
        /// Definisemo request handling pipeline i konfigurisemo sve servise koji nam trebaju u aplikaciji
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) // servisi su objekti sa funkcionalnostima za druge delove aplikacije
        {
            services.AddDbContext<PornDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<PornDbContext>();//basic functionality for working with Identity in your application

            services.AddScoped<IPieRepository, PieRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));
            services.AddHttpContextAccessor();
            services.AddSession();
            //Transient-svaki put kad od kontejnera trazimo instancu dobicemo novu; AddSingleton svaki put kad trazimo instancu dobicemo istu; AddScoped jedna instanca po http requestu ali koristi tu istu instancu kroz sve pozive u okviru istog requesta
            //services.AddTransient;
            //services.AddSingleton();
            services.AddRazorPages();
            services.AddControllersWithViews();
            services.AddRazorPages(); //jer Identity koristi razor pages koje smo izgenerisali 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();//css, javascript, slike,. ; po defaultu to trazi u wwwroot, to moze menja

            app.UseSession();

            app.UseRouting(); //inejbluje mvc da odgovara requestima
            app.UseAuthentication(); //https://app.pluralsight.com/course-player?clipId=f9a7b1cf-0c7f-4c90-9482-ebfa6c07de08
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints => // ovaj ovde deo je odgovoran da mapira pristizuci request sa akcijom na kontroleru
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages(); //dodajemo zbog Identitya
            });
        }
    }
}

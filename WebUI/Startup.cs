using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebUI.Contract;
using WebUI.EF;
using WebUI.Entities;
using WebUI.Models;

namespace WebUI
{
    public class Startup
    {
        IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    options.CheckConsentNeeded = context => true; // consent required
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});

            services.AddSession(opts =>
            {
                opts.Cookie.IsEssential = true; // make the session cookie Essential
            });
            services.AddScoped<Basket>(b => SessionBasket.GetBasket(b)); //???
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //???
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IProductRep, ProductRep>();
            services.AddTransient<IOrderRep, OrderRep>();

            services.AddMemoryCache(); //???
            services.AddSession();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseSession();
            app.UseMvc(r =>
            {
                r.MapRoute(name: null,
                          template: "{controller}/{action}/{category?}/{page?}/{id?}",
                          defaults: new { controller = "Admin", action = "Index", page = 1 });
                r.MapRoute(
                name: null,
                template: "Page{page:int}",
                defaults: new { controller = "Product", action = "List", page = 1 }
                );
            });
        }
    }
}

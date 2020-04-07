using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using APIGateway.DB;
using APIGateway.Extensions;
using APIGateway.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

/**
 * @author WUYUDING
 */
namespace APIGateway
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
            services.AddControllersWithViews();

            //inject the service
            services.AddScoped<HttpClient>();
            services.AddScoped<DataFetcher>();
            //inject dbcontext
            services.AddDbContext<ShoppingContext>(opt =>
                opt.UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("DbConn")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ShoppingContext dbcontext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //use extenstions to register middleware
            app.UseMiddlewareExtensions();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //create database and table
            dbcontext.Database.EnsureDeleted();
            dbcontext.Database.EnsureCreated();

            //insert data into database
            new DBSeeder(dbcontext);

        }
    }
}

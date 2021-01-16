using AutoLibrary.Services;
using AutoLibrary.SqlConnectionData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoWeb
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
            //enable runtime compilation 
            //nuget package addad: Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddRazorPages();

            services.AddSingleton(new SqlConnectionString { SqlConnectionName = "Default" });

            services.AddSingleton<ISqlDataAccess, SqlDataAccess>();

            services.AddSingleton<ICategoryData, CategoryData>();

            services.AddSingleton<ICodeData, CodeData>();

            services.AddSingleton<IBrandData, BrandData>();

            services.AddSingleton<IAutoData, AutoData>();

            services.AddSingleton<IReviewData, ReviewData>();

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

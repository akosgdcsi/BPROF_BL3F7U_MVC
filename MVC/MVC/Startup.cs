using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Models;
using Repository;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MVC
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(opt => opt.EnableEndpointRouting = false).AddRazorRuntimeCompilation();
            services.AddTransient<PlanetLogic, PlanetLogic>();
            services.AddTransient<StarLogic, StarLogic>();
            services.AddTransient<SystemLogic, SystemLogic>();
            services.AddTransient<StatsLogic, StatsLogic>();
            services.AddTransient<IRepository<Planet>, PlanetRepository>();
            services.AddTransient<IRepository<Star>, StarRepository>();
            services.AddTransient<IRepository<Models.System>, SystemRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}

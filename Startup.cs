using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //In netcore 3.0 and above you cannot use Mvc with Default use without putting 0ption EnableEndpointRouting to false 
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddSingleton<IEmployeeRepository, MockEmployeerepository>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=home}/{action=index}/{id?}");
            
            });
             


           

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApplication13.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication13.Models;
using System.Globalization;
using Microsoft.Xrm.Sdk;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;

namespace WebApplication13
{
    public class Startup
    {
        public Startup(IConfiguration configuration, string AuthenticationType)
        {
            Configuration = configuration;
            AuthenticationType = "ApplicationCookie";
            PathString LoginPath = new PathString("/users/Login");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string Connectionstring = "Server = .; Database=BOOKES;Integrated Security = true;";
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<TodoContaxt>().AddDefaultTokenProviders();


            services.AddDbContext<TodoContaxt>(opt => opt.UseSqlServer(Connectionstring));
            services.AddControllers();

            services.AddIdentityCore<User>()
              .AddEntityFrameworkStores<TodoContaxt>()
              .AddDefaultUI();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

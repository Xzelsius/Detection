using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wangkanai.Detection;
using Wangkanai.Detection.Models;

namespace ResponsiveOption
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
            // Add responsive services.
            services.AddDetection(options =>
            {
                options.Responsive.DefaultTablet  = Device.Desktop;
                options.Responsive.DefaultMobile  = Device.Mobile;
                options.Responsive.DefaultDesktop = Device.Desktop;
                options.Responsive.IncludeWebApi  = true;
                options.Responsive.PathWebApi     = "/Api";
                options.Responsive.PathViews      = "/Views";
                options.Responsive.PathPages      = "/Pages";
            });

            // Add framework services.
            services.AddControllersWithViews();
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
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseDetection();

            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }
    }
}
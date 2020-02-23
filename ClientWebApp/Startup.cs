using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientWebApp.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using SupportUpdateAPICore;
//using SupportUpdateClient;

namespace ClientWebApp
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

            //services.AddMvc().AddRazorPagesOptions();

            services.AddRazorPages()
            .AddNewtonsoftJson();

            services.AddHttpClient<StatusService>(c =>
            {
                c.BaseAddress = new Uri(Configuration.GetSection("Api").Value);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
                c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            });

            // Now let's register an API client for your AJAX call.
            // Includes the configuration - base address & content type.
            //services.AddHttpClient("API Client", client =>
            //{
            //// client.BaseAddress = new Uri("https://www.metaweather.com/");
            //client.BaseAddress = new Uri(Configuration.GetSection("Api").Value);
            //client.DefaultRequestHeaders.Add("Accept", "application/json");
            //});

            //services.AddHttpClient<IStatusClient,
            //               StatusClient>(client =>
            // client.BaseAddress = new Uri(Configuration.GetSection("Api").Value));


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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}

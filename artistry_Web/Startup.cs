using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using artistry_Data.Context;
using artistry_Data.DAL;
using artistry_Web.Helper;
using artistry_Web.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using Stripe;

namespace artistry_Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public class StripeSettings
        {
            public string SecretKey { get; set; }
            public string PublishableKey { get; set; }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options=>options.UseSqlServer
            ("Data Source=den1.mssql1.gear.host; Initial Catalog = artistry; Integrated Security=False;User ID=artistry;Password=Adna1!;"));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IFileProvider>(
            new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));

            services.AddMvc();

            services.AddScoped<LogFilter>();
            services.AddScoped<IMuseumRepository, MuseumRepository>();


            services.AddDistributedMemoryCache();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            GlobalDiagnosticsContext.Set("configDir", "Nlog.log");
            GlobalDiagnosticsContext.Set("connectionString", "Data Source=den1.mssql1.gear.host; Initial Catalog = artistry; Integrated Security=False;User ID=artistry;Password=Adna1!;");

            StripeConfiguration.SetApiKey("sk_test_3RYpHa2Dsbr6Q3HDXb6KVfGj");

            loggerFactory.AddNLog();

           // env.ConfigureNLog("nlog.config");

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Home/Error");
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<Context>();
                context.Database.EnsureCreated();
            }

            app.UseSession();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
         name: "areaRoute",
         template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

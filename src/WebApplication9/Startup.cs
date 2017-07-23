using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication9.Services;
using Microsoft.Extensions.Configuration;
//using Microsoft.DotNet.InternalAbstractions;
using WebApplication9.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Entity;

namespace WebApplication9
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            var builder = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath).AddJsonFile("config.json").AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //services.AddEntityFramework().AddSqlServer().AddDbContext<PortContext>(options => options.UseSqlServer(Configuration["Data:PortContextConnection"]));
            var sqlConnectionString = Configuration["Data:PortContextConnection"]

            services.AddDbContext<PortContext>(options =>
              options.UseSqlServer(
                sqlConnectionString,
                b => b.MigrationsAssembly("WebApplication9")
              )
            );
            //services.AddDbContext<PortContext>();

            //if (env.IsDevelopment())
            //{
            //    services.AddScoped<IMailService, IDebugMailService>();
            //}
            //else
            //{
            services.AddScoped<IMailService, MailService>();
            //}
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole();
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //app.UseRequestLocalization();
            app.UseStaticFiles();
            app.UseMvc( config => {
                config.MapRoute(
                     name: "default",
                     template: "{controller}/{action}/{id?}",
                     defaults: new { controller = "App", action = "Index" }
                    );
            });
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

        }
    }
}

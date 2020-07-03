using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using BlazorDeveloperHubApi.Interfaces;
using BlazorDeveloperHubApi.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace BlazorDeveloperHubApi
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "_MyAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;           
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
            }).AddNewtonsoftJson();
            //Add this to specify connection to Database
            services.AddDbContext<DeveloperhubDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DbCon"));

            });//

            //Cors configuration
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                        //.AllowCredentials();
                    });
            });

            services.AddMvc();
            //.AddMvcOptions(opt => {
            //    opt.EnableEndpointRouting = false;
            //}) ;
            // Add the middleware
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.DictionaryKeyPolicy = null;
               
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            //Add swagger service
             services.AddSwaggerGen(s =>
              {
                  s.EnableAnnotations();
                  s.SwaggerDoc(name: "v1",
                      new OpenApiInfo
                      {
                          Version = "v1",
                          Title = "DeveloperHubAPI",
                          Description = "Developer Hub API",
                          Contact = new OpenApiContact
                          {
                            Name = "API support",
                            Url =  new Uri("https://twitter.com/Nweke_Franchise"),                         
                          },
                          License = new OpenApiLicense
                          {
                              Name = "Use under Datalinks",
                              Url = new Uri("http://www.datalinksltd.com"),
                          }
                      });

                  //var filePath = Path.Combine(System.AppContext.BaseDirectory, "BlazorDeveloperHubApi.xml");
                  //s.IncludeXmlComments(filePath);
              });

            services.AddScoped<IDeveloper, DeveloperRepository>();
            services.AddScoped<ICity, CityRepository>();
            services.AddScoped<ICountry, CountryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Add UseSwagger() and UseSwaggerUI
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Example);
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "DeveloperHubAPI Version 1");
                s.RoutePrefix = string.Empty;  
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(MyAllowSpecificOrigins);
            //app.UseMvc(routes => {
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{Controller}/{action=Index}/{id?}"
            //        );
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("default", "{Controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

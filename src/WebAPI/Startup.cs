using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using WebAPI.Services.Generics;
using WebAPI.Services.LifeCycles;
using WebAPI.Services.MultiInjections;
using WebAPI.Services.PropertyInjections;
using WebAPI.Services.ServiceLocators;

namespace WebAPI
{
    public class Startup
    {
        public const string SWAGGER_ROUTE_PREFIX = "swagger";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });


            #region LIFE CYCLES
            services.AddTransient<LifeCycleService>();

            services.AddTransient<ITransientService, TransientService>();
            services.AddScoped<IScopedService, ScopedService>();
            services.AddSingleton<ISingletonService, SingletonService>();
            services.AddSingleton<ISingletonInstanceService>(new SingletonInstanceService("Hellow world!!", DateTime.UtcNow));
            #endregion


            #region GENERIC INJECTIONS
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            #endregion


            #region PROPERTY INJECTIONS
            services.AddScoped<IPropertyService, PropertyService>();
            #endregion


            #region SERVICE LOCATORS
            services.AddScoped<ILocatorService, LocatorService>();
            #endregion


            #region MULTI INJECTIONS
            services.AddScoped<PortugalService>();
            services.AddScoped<NetherlandsService>();
            services.AddScoped<IrelandService>();
            services.AddScoped<Func<string, ICountryService>>(serviceProvider => countryCode =>
            {
                switch(countryCode?.ToLower())
                {
                    case "pt": return serviceProvider.GetService<PortugalService>();
                    case "nl": return serviceProvider.GetService<NetherlandsService>();
                    case "ie": return serviceProvider.GetService<IrelandService>();
                    default: return null;
                }
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(u =>
            {
                u.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
                u.RoutePrefix = SWAGGER_ROUTE_PREFIX;
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
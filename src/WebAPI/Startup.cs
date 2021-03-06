using System;
using DemoWebAPI.Services.Examples;
using DemoWebAPI.Services.Generics;
using DemoWebAPI.Services.LifeCycles;
using DemoWebAPI.Services.MultiInjections;
using DemoWebAPI.Services.PropertyInjections;
using DemoWebAPI.Services.ServiceLocators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DemoWebAPI;

public class Startup
{
    public const string SWAGGER_ROUTE_PREFIX = "swagger";

    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
        => Configuration = configuration;


    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen(c
            => c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" })
        );


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
        services.AddScoped<Func<string, ICountryService>>(serviceProvider =>
            countryCode => (countryCode?.ToLower()) switch
            {
                "pt" => serviceProvider.GetService<PortugalService>(),
                "nl" => serviceProvider.GetService<NetherlandsService>(),
                "ie" => serviceProvider.GetService<IrelandService>(),
                _ => null,
            });
        #endregion


        # region OTHER EXAMPLES
        services.AddScoped<IExampleService, ExampleService>();
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

        app.UseEndpoints(endpoints
            => endpoints.MapControllers()
        );
    }
}

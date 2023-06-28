using System;
using DemoWebAPI.Services.DelegateFunc;
using DemoWebAPI.Services.DelegateFuncs;
using DemoWebAPI.Services.Examples;
using DemoWebAPI.Services.Generics;
using DemoWebAPI.Services.LifeCycles;
using DemoWebAPI.Services.MultiInjections;
using DemoWebAPI.Services.PropertyInjections;
using DemoWebAPI.Services.ServiceLocators;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            => c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" }));


        #region MULTI INJECTIONS
        services.AddScoped<PortugalService>()
                .AddScoped<NetherlandsService>()
                .AddScoped<IrelandService>()
                .AddScoped<Func<string, ICountryService>>(sp =>
                    countryCode => (countryCode?.ToLower()) switch
                    {
                        "pt" => sp.GetService<PortugalService>(),
                        "nl" => sp.GetService<NetherlandsService>(),
                        "ie" => sp.GetService<IrelandService>(),
                        _ => null,
                    });

        services.AddTransient<SumFunc>(s => FuncUtils.SumFunc);
        #endregion


        #region LIFE CYCLES
        services.AddTransient<LifeCycleService>();

        services.AddTransient<ITransientService, TransientService>()
                .AddScoped<IScopedService, ScopedService>()
                .AddSingleton<ISingletonService, SingletonService>()
                .AddSingleton<ISingletonInstanceService>(new SingletonInstanceService(
                    "Hellow world!!",
                    DateTime.UtcNow));
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


        #region OTHER EXAMPLES
        services.AddScoped<IExampleService, ExampleService>();
        #endregion


        #region MULTI INJECTIONS
        services.AddScoped<IMultiInjection, MultiInjectionAService>();
        services.AddScoped<IMultiInjection, MultiInjectionBService>();
        services.AddScoped<IMultiInjection, MultiInjectionCService>();
        #endregion
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseDeveloperExceptionPage();

        app.UseSwagger()
           .UseSwaggerUI(u =>
            {
                u.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
                u.RoutePrefix = SWAGGER_ROUTE_PREFIX;
            });

        app.UseRouting()
           .UseEndpoints(endpoints =>
                endpoints.MapControllers());
    }
}

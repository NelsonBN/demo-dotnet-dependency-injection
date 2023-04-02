using DemoWorker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

await Host
    .CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddScoped<IScopedService, ScopedService>();
        services.AddHostedService<Worker>();
    })
    .Build()
    .RunAsync();

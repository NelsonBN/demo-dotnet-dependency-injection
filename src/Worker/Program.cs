using DemoWorker;
using DemoWorker.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddScoped<IScopedService, ScopedService>();

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();

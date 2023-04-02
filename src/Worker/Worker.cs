using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DemoWorker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IServiceProvider _serviceProvider;

    public Worker(
        ILogger<Worker> logger,
        IServiceProvider serviceProvider
    )
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while(!stoppingToken.IsCancellationRequested)
        {
            using(var scope = _serviceProvider.CreateScope())
            {
                var service =
                    scope.ServiceProvider.GetRequiredService<IScopedService>();

                _logger
                    .LogInformation($"Service: {service.GetInstantiationDetails()}");
            }


            await Task.Delay(1000, stoppingToken);
        }
    }
}

using Microsoft.Extensions.Logging;
using System;

namespace WebAPI.Services.LifeCycles;

public class SingletonService : ISingletonService
{
    private static uint _instantiationCount;

    private readonly ILogger<SingletonService> _logger;

    public Guid ServiceId { get; private set; }

    public SingletonService(ILogger<SingletonService> logger)
    {
        _logger = logger;

        ServiceId = Guid.NewGuid();
        _instantiationCount++;
    }

    public string GetInstantiationDetails()
        => $"{nameof(SingletonService)} > InstantiationCount: {_instantiationCount}, ServiceId: {ServiceId}";

    public void Dispose()
    {
        _logger.LogInformation("Dispose");
        GC.SuppressFinalize(this);
    }
}

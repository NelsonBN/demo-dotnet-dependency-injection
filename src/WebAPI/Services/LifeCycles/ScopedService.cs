using System;
using Microsoft.Extensions.Logging;

namespace DemoWebAPI.Services.LifeCycles;

public class ScopedService : IScopedService
{
    private static uint _instantiationCount;

    private readonly ILogger<ScopedService> _logger;

    public Guid ServiceId { get; private set; }

    public ScopedService(ILogger<ScopedService> logger)
    {
        _logger = logger;

        ServiceId = Guid.NewGuid();
        _instantiationCount++;
    }

    public string GetInstantiationDetails()
        => $"{nameof(ScopedService)} > InstantiationCount: {_instantiationCount}, ServiceId: {ServiceId}";

    public void Dispose()
    {
        _logger.LogInformation("Dispose");
        GC.SuppressFinalize(this);
    }
}

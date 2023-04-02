using System;
using Microsoft.Extensions.Logging;

namespace DemoWebAPI.Services.LifeCycles;

public interface ISingletonService : IDisposable
{
    Guid ServiceId { get; }
    string GetInstantiationDetails();
}

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

    public void Dispose() => _logger.LogInformation("Dispose");
}

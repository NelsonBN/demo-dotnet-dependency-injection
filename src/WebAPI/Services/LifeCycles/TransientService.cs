﻿using System;
using Microsoft.Extensions.Logging;

namespace DemoWebAPI.Services.LifeCycles;

public interface ITransientService : IDisposable
{
    Guid ServiceId { get; }
    string GetInstantiationDetails();
}

public class TransientService : ITransientService
{
    private static uint _instantiationCount;

    private readonly ILogger<TransientService> _logger;

    public Guid ServiceId { get; private set; }

    public TransientService(ILogger<TransientService> logger)
    {
        _logger = logger;

        ServiceId = Guid.NewGuid();
        _instantiationCount++;
    }

    public string GetInstantiationDetails()
        => $"{nameof(TransientService)} > InstantiationCount: {_instantiationCount}, ServiceId: {ServiceId}";

    public void Dispose() => _logger.LogInformation("Dispose");
}

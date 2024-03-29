﻿namespace DemoWebAPI.Services.LifeCycles;

public class LifeCycleService
{
    private readonly ITransientService _transientService;
    private readonly IScopedService _scopedService;
    private readonly ISingletonService _singletonService;
    private readonly ISingletonInstanceService _singletonInstanceService;

    public LifeCycleService(
        ITransientService transientService,
        IScopedService scopedService,
        ISingletonService singletonService,
        ISingletonInstanceService singletonInstanceService)
    {
        _transientService = transientService;
        _scopedService = scopedService;
        _singletonService = singletonService;
        _singletonInstanceService = singletonInstanceService;
    }

    public string GetInstantiationDetails()
        => $"""
            {_transientService.GetInstantiationDetails()}
                {_scopedService.GetInstantiationDetails()}
                {_singletonService.GetInstantiationDetails()}
                {_singletonInstanceService.GetInstantiationDetails()}
            """;
}

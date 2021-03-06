using System;

namespace DemoWebAPI.Services.LifeCycles;

public interface IScopedService : IDisposable
{
    Guid ServiceId { get; }
    string GetInstantiationDetails();
}

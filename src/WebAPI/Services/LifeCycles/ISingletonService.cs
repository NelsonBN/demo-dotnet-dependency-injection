using System;

namespace DemoWebAPI.Services.LifeCycles;

public interface ISingletonService : IDisposable
{
    Guid ServiceId { get; }
    string GetInstantiationDetails();
}

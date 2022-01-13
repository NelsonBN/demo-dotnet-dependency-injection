using System;

namespace DemoWorker.Services;

public interface IScopedService : IDisposable
{
    Guid ServiceId { get; }
    string GetInstantiationDetails();
}

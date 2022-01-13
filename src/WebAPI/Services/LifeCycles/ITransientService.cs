using System;

namespace DemoWebAPI.Services.LifeCycles;

public interface ITransientService : IDisposable
{
    Guid ServiceId { get; }
    string GetInstantiationDetails();
}

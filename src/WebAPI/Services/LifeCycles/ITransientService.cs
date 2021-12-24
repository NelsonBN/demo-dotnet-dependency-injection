using System;

namespace WebAPI.Services.LifeCycles;

public interface ITransientService : IDisposable
{
    Guid ServiceId { get; }
    string GetInstantiationDetails();
}

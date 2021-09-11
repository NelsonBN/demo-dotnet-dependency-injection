using System;

namespace WebAPI.Services.LifeCycles
{
    public interface IScopedService : IDisposable
    {
        Guid ServiceId { get; }
        string GetInstantiationDetails();
    }
}
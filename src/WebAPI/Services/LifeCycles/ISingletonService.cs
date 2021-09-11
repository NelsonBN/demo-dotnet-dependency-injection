using System;

namespace WebAPI.Services.LifeCycles
{
    public interface ISingletonService : IDisposable
    {
        Guid ServiceId { get; }
        string GetInstantiationDetails();
    }
}
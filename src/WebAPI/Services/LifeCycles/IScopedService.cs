using System;

namespace WebAPI.Services.LifeCycles
{
    public interface IScopedService
    {
        Guid ServiceId { get; }
        string GetInstantiationDetails();
    }
}
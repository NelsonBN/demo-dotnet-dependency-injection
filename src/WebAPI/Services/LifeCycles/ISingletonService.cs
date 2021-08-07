using System;

namespace WebAPI.Services.LifeCycles
{
    public interface ISingletonService
    {
        Guid ServiceId { get; }
        string GetInstantiationDetails();
    }
}
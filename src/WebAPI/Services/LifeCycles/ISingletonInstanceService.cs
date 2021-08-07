using System;

namespace WebAPI.Services.LifeCycles
{
    public interface ISingletonInstanceService
    {
        Guid ServiceId { get; }
        string GetInstantiationDetails();
    }
}
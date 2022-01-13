using System;

namespace DemoWebAPI.Services.LifeCycles;

public interface ISingletonInstanceService
{
    Guid ServiceId { get; }
    string GetInstantiationDetails();
}

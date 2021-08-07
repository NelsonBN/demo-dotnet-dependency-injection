using System;

namespace WebAPI.Services.LifeCycles
{
    public interface ITransientService
    {
        Guid ServiceId { get; }
        string GetInstantiationDetails();
    }
}
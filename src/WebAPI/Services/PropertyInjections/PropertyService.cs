using System;

namespace DemoWebAPI.Services.PropertyInjections;

public interface IPropertyService
{
    DateTime GetDateTime();
}

public class PropertyService : IPropertyService
{
    public DateTime GetDateTime()
        => DateTime.UtcNow;
}

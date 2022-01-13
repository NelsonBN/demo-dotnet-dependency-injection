using System;

namespace DemoWebAPI.Services.PropertyInjections;

public class PropertyService : IPropertyService
{
    public DateTime GetDateTime()
        => DateTime.UtcNow;
}

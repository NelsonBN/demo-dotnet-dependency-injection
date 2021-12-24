using System;

namespace WebAPI.Services.PropertyInjections;

public class PropertyService : IPropertyService
{
    public DateTime GetDateTime()
        => DateTime.UtcNow;
}
